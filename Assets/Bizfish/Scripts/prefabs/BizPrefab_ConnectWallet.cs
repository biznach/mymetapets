using System.Collections.Generic;
using UnityEngine;
using Thirdweb;
using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public enum BizWallet
{
    MetaMask,
    Injected,
    CoinbaseWallet,
    WalletConnect,
    MagicAuth,
}

[Serializable]
public struct BizWalletButton
{
    public BizWallet wallet;
    public GameObject walletButton;
    public Sprite icon;
}

[Serializable]
public struct BizNetworkSprite
{
    public BizChain chain;
    public Sprite sprite;
}

public class BizPrefab_ConnectWallet : MonoBehaviour
{
    [Header("SETTINGS")]
    public List<BizWallet> supportedWallets;
    public bool supportSwitchingNetwork;

    [Header("CUSTOM CALLBACKS")]
    public UnityEvent OnConnectedCallback;
    public UnityEvent OnDisconnectedCallback;
    public UnityEvent OnSwitchNetworkCallback;

    [Header("UI ELEMENTS (DO NOT EDIT)")]
    // Connecting
    public GameObject connectButton;
    public GameObject connectDropdown;
    public List<BizWalletButton> walletButtons;
    // Connected
    public GameObject connectedButton;
    public GameObject connectedDropdown;
    public TMP_Text balanceText;
    public TMP_Text walletAddressText;
    public Image walletImage;
    public TMP_Text currentNetworkText;
    public Image currentNetworkImage;
    public Image chainImage;
    // Network Switching
    public GameObject networkSwitchButton;
    public GameObject networkDropdown;
    public GameObject networkButtonPrefab;
    public List<BizNetworkSprite> networkSprites;

    string address;
    BizWallet wallet;


    // UI Initialization

    private void Start()
    {
        address = null;

        if (supportedWallets.Count == 1)
            connectButton.GetComponent<Button>().onClick.AddListener(() => OnConnect(supportedWallets[0]));
        else
            connectButton.GetComponent<Button>().onClick.AddListener(() => OnClickDropdown());


        foreach (BizWalletButton wb in walletButtons)
        {
            if (supportedWallets.Contains(wb.wallet))
            {
                wb.walletButton.SetActive(true);
                wb.walletButton.GetComponent<Button>().onClick.AddListener(() => OnConnect(wb.wallet));
            }
            else
            {
                wb.walletButton.SetActive(false);
            }
        }

        connectButton.SetActive(true);
        connectedButton.SetActive(false);

        connectDropdown.SetActive(false);
        connectedDropdown.SetActive(false);

        networkSwitchButton.SetActive(supportSwitchingNetwork);
        networkDropdown.SetActive(false);
    }

    // Connecting

    public async void OnConnect(BizWallet _wallet)
    {
        try
        {
            address = await BizwebManager.Instance.SDK.wallet.Connect(
               new WalletConnection()
               {
                   provider = GetWalletProvider(_wallet),
                   chainId = (int)BizwebManager.Instance.chain,
               });

            wallet = _wallet;
            OnConnected();
            if (OnConnectedCallback != null)
                OnConnectedCallback.Invoke();
            print($"Connected successfully to: {address}");
        }
        catch (Exception e)
        {
            print($"Error Connecting Wallet: {e.Message}");
        }
    }

    async void OnConnected()
    {
        try
        {
            BizChain _chain = BizwebManager.Instance.chain;
            CurrencyValue nativeBalance = await BizwebManager.Instance.SDK.wallet.GetBalance();
            balanceText.text = $"{nativeBalance.value.ToEth()} {nativeBalance.symbol}";
            walletAddressText.text = address.ShortenAddress();
            currentNetworkText.text = BizwebManager.Instance.chainIdentifiers[_chain];
            currentNetworkImage.sprite = networkSprites.Find(x => x.chain == _chain).sprite;
            connectButton.SetActive(false);
            connectedButton.SetActive(true);
            connectDropdown.SetActive(false);
            connectedDropdown.SetActive(false);
            networkDropdown.SetActive(false);
            walletImage.sprite = walletButtons.Find(x => x.wallet == wallet).icon;
            chainImage.sprite = networkSprites.Find(x => x.chain == _chain).sprite;
        }
        catch (Exception e)
        {
            print($"Error Fetching Native Balance: {e.Message}");
        }

    }

    // Disconnecting

    public async void OnDisconnect()
    {
        try
        {
            await ThirdwebManager.Instance.SDK.wallet.Disconnect();
            OnDisconnected();
            if (OnDisconnectedCallback != null)
                OnDisconnectedCallback.Invoke();
            print($"Disconnected successfully.");

        }
        catch (Exception e)
        {
            print($"Error Disconnecting Wallet: {e.Message}");
        }
    }

    void OnDisconnected()
    {
        address = null;
        connectButton.SetActive(true);
        connectedButton.SetActive(false);
        connectDropdown.SetActive(false);
        connectedDropdown.SetActive(false);
    }

    // Switching Network

    public async void OnSwitchNetwork(BizChain _chain)
    {

        try
        {
            BizwebManager.Instance.chain = _chain;
            await BizwebManager.Instance.SDK.wallet.SwitchNetwork((int)_chain);
            OnConnected();
            if (OnSwitchNetworkCallback != null)
                OnSwitchNetworkCallback.Invoke();
            print($"Switched Network Successfully: {_chain}");

        }
        catch (Exception e)
        {
            print($"Error Switching Network: {e.Message}");
        }
    }

    // UI

    public void OnClickDropdown()
    {
        if (String.IsNullOrEmpty(address))
            connectDropdown.SetActive(!connectDropdown.activeInHierarchy);
        else
            connectedDropdown.SetActive(!connectedDropdown.activeInHierarchy);
    }

    public void OnClickNetworkSwitch()
    {
        if (networkDropdown.activeInHierarchy)
        {
            networkDropdown.SetActive(false);
            return;
        }

        networkDropdown.SetActive(true);

        foreach (Transform child in networkDropdown.transform)
            Destroy(child.gameObject);

        foreach (BizChain chain in Enum.GetValues(typeof(BizChain)))
        {
            if (chain == BizwebManager.Instance.chain || !BizwebManager.Instance.supportedNetworks.Contains(chain))
                continue;

            GameObject networkButton = Instantiate(networkButtonPrefab, networkDropdown.transform);
            networkButton.GetComponent<Button>().onClick.RemoveAllListeners();
            networkButton.GetComponent<Button>().onClick.AddListener(() => OnSwitchNetwork(chain));
            networkButton.transform.Find("Text_Network").GetComponent<TMP_Text>().text = BizwebManager.Instance.chainIdentifiers[chain];
            networkButton.transform.Find("Icon_Network").GetComponent<Image>().sprite = networkSprites.Find(x => x.chain == chain).sprite;
        }
    }

    // Utility

    WalletProvider GetWalletProvider(BizWallet _wallet)
    {
        switch (_wallet)
        {
            case BizWallet.MetaMask:
                return WalletProvider.MetaMask;
            case BizWallet.Injected:
                return WalletProvider.Injected;
            case BizWallet.CoinbaseWallet:
                return WalletProvider.CoinbaseWallet;
            case BizWallet.WalletConnect:
                return WalletProvider.WalletConnect;
            case BizWallet.MagicAuth:
                return WalletProvider.MagicAuth;
            default:
                throw new UnityException($"Wallet Provider for wallet {_wallet} unimplemented!");
        }
    }
}
