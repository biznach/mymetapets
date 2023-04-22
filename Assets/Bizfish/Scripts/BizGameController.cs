//using MoralisUnity;
//using MoralisUnity.Kits.AuthenticationKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thirdweb;


public class BizGameController : MonoBehaviour
{

    [Header("FishSchoolController")]

    [SerializeField]
    private BizSchoolController schoolController = null;

    [SerializeField]
    public int fishCount = 0;

    [Header("ObjectReferences")]

    [SerializeField]
    private GameObject managerObject = null;

    [SerializeField]
    private GameObject controllerObject = null;

    [SerializeField]
    private GameObject uiCanvas = null;
    
    [Header("Contracts")]

    [SerializeField]
    const string TOKEN_ERC1155_CONTRACT = "0x89bB19B45C8481D9d0A48bE4B1287fBc54Ee7506";
    
    private ThirdwebManager managerScript = null;

    private BizHUDController controllerScript = null;

    private bool isShowing = true;

    private string fishCountString = "0";

    private void Start()
    {
        managerScript = managerObject.GetComponent<ThirdwebManager>();
        controllerScript = controllerObject.GetComponent<BizHUDController>();
    }
    private void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            if (controllerObject.activeInHierarchy == true)
            {
                isShowing = !isShowing;
                uiCanvas.SetActive(isShowing);
            }
        }
    }

    void OnEnable()
    {
        Debug.Log("PrintOnDisable: script was enabled");
        //schoolController.SetFishAmount(0);
    }

    void OnDisable()
    {
        Debug.Log("PrintOnDisable: script was disabled");
        //schoolController.SetFishAmount(0);
    }

    public void Authentication_OnConnect()
    {
        GetNFTCount();
    }

    public void Authentication_OnDisconnect()
    {
        //controllerObject.SetActive(false);
    }

    public async void GetNFTCount()
    {
        try
        {
            Contract contract = ThirdwebManager.Instance.SDK.GetContract(TOKEN_ERC1155_CONTRACT);

            fishCountString = await contract.ERC1155.Balance("1");
            fishCount = System.Convert.ToInt32(fishCountString);

            //Debugger.Instance.Log("[GetNFTCount] Count", fishCountString);
            Debug.Log("[GetNFTCount] Count " + fishCountString);
            controllerScript.UpdateBalance("Fish: " + fishCountString);

            schoolController.SetFishAmount(fishCount);
        }
        catch (System.Exception e)
        {
            Debugger.Instance.Log("[GetNFTCount] Error", e.Message);
        }
    }
    //public async void UpdateHud()
    //{
            //TBD
    //}

    //public async void UpdateHud()
    //{
        //Debug.Log("PrintOnDisable: script was enabled");
        //schoolController.SetFishAmount(fishCount);
        //if (MoralisState.Initialized.Equals(Moralis.State))
        //{
        //    MoralisUser user = await Moralis.GetUserAsync();

        //    if (user == null)
        //    {
                // User is null so go back to the authentication scene.
        //        SceneManager.LoadScene(0);
        //    }

            // Display User's wallet address.
        //    addressText.text = FormatUserAddressForDisplay(user.ethAddress);

            // Retrienve the user's native balance;
        //    NativeBalance balanceResponse = await Moralis.Web3Api.Account.GetNativeBalance(user.ethAddress, Moralis.CurrentChain.EnumValue);

        //    double balance = 0.0;
        //    float decimals = Moralis.CurrentChain.Decimals * 1.0f;
        //    string sym = Moralis.CurrentChain.Symbol;

            // Make sure a response to the balanace request weas received. The 
            // IsNullOrWhitespace check may not be necessary ...
        //    if (balanceResponse != null && !string.IsNullOrWhiteSpace(balanceResponse.Balance))
        //    {
        //       double.TryParse(balanceResponse.Balance, out balance);
        //    }

            // Display native token amount token in fractions of token.
            // NOTE: May be better to link this to chain since some tokens may have
            // more than 18 sigjnificant figures.
            //balanceText.text = string.Format("{0:0.####} {1}", (balance / (double)Mathf.Pow(10.0f, decimals)), sym);

            //BIZ BALANCE
        //    NftOwnerCollection nftCollection = await Moralis.Web3Api.Account.GetNFTsForContract(user.ethAddress, contractAddress, ChainList.mumbai);
        //    List<NftOwner> nftOwners = nftCollection.Result;
        //    string fishCountString = "0";
        //    if (nftCollection.Total < 1)
        //    {
        //        Debug.Log($"User {user.ethAddress} does not have any NFTs");
        //        schoolController.SetFishAmount(0);
        //    }
        //    else
        //    {
        //        fishCountString = nftOwners[0].Amount;
        //        fishCount = System.Convert.ToInt32(fishCountString);
        //        schoolController.SetFishAmount(fishCount);
                //schoolController.SetFishAmount(5);

        //    }
        //    balanceText.text = $"Clownfish: {fishCountString}";
        //}
    //}
}
