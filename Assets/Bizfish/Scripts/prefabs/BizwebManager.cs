using UnityEngine;
using Thirdweb;
using System.Collections.Generic;

[System.Serializable]
public enum BizChain
{
    Ethereum = 1,
    Goerli = 5,
    Polygon = 137,
    Mumbai = 80001,
    Fantom = 250,
    FantomTestnet = 4002,
    Avalanche = 43114,
    AvalancheTestnet = 43113,
    Optimism = 10,
    OptimismGoerli = 420,
    Arbitrum = 42161,
    ArbitrumGoerli = 421613,
    Binance = 56,
    BinanceTestnet = 97
}

public class BizwebManager : MonoBehaviour
{
    [Header("SETTINGS")]
    public BizChain chain = BizChain.Goerli;
    public List<BizChain> supportedNetworks;

    public Dictionary<BizChain, string> chainIdentifiers = new Dictionary<BizChain, string>
    {
        {BizChain.Ethereum, "ethereum"},
        {BizChain.Goerli, "goerli"},
        {BizChain.Polygon, "polygon"},
        {BizChain.Mumbai, "mumbai"},
        {BizChain.Fantom, "fantom"},
        {BizChain.FantomTestnet, "testnet"},
        {BizChain.Avalanche, "avalanche"},
        {BizChain.AvalancheTestnet, "avalanche-testnet"},
        {BizChain.Optimism, "optimism"},
        {BizChain.OptimismGoerli, "optimism-goerli"},
        {BizChain.Arbitrum, "arbitrum"},
        {BizChain.ArbitrumGoerli, "arbitrum-goerli"},
        {BizChain.Binance, "binance"},
        {BizChain.BinanceTestnet, "binance-testnet"},
    };

    public ThirdwebSDK SDK;

    public static BizwebManager Instance;

    public static string mainContractAddress = "0x9ec4bA8A3A7b4De67f44Ac97c8b35aF3BeDea450";
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);

#if !UNITY_EDITOR
        SDK = new ThirdwebSDK(chainIdentifiers[chain]);
#endif
    }

}
