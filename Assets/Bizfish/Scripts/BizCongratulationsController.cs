//using MoralisUnity;
//using MoralisUnity.Platform.Objects;
//using MoralisUnity.Web3Api.Models;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MoralisUnity.Demos.Introduction
{
    public class BizCongratulationsController : MonoBehaviour
    {
        [Header("Texts")]
        [SerializeField]
        private Text addressText;

        [SerializeField]
        private Text balanceText;

        [Header("Buttons")]
        [SerializeField]
        private Button backButton = null;

        [Header("Controller")]
        [SerializeField]
        private BizSchoolController schoolController = null;

        private string contractAddress = "0x89bB19B45C8481D9d0A48bE4B1287fBc54Ee7506";

        private int fishCount = 0;

        // Start is called before the first frame update
        void Start()
        {
            if (addressText == null)
            {
                Debug.LogError("Address Text not set.");
                return;
            }

            if (balanceText == null)
            {
                Debug.LogError("Balance Text not set.");
                return;
            }

            if (backButton == null)
            {
                Debug.LogError("Back Button not set.");
                return;
            }
        }

        void OnDisable()
        {
            Debug.Log("PrintOnDisable: script was disabled");
            schoolController.SetFishAmount(0);
        }

        //async void OnEnable()
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

        //private string FormatUserAddressForDisplay(string addr)
        //{
        //    string resp = addr;

        //    if (resp.Length > 13)
        //    {
        //        resp = string.Format("{0}...{1}", resp.Substring(0, 6), resp.Substring(resp.Length - 4, 4));
        //    }

        //    return resp;
        //}
    }
}
