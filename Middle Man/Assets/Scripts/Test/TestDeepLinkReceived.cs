using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cards;
using DeepLink;



namespace Test
{
    public class TestDeepLinkReceived : MonoBehaviour
    {
        #region /* Controllers */
        
        private CardGenerator CardGenerator { get; set; }

        public DeepLinkManager DeepLinkManager;

        #endregion



        #region === Unity Events ===

        // Start is called before the first frame update
        void Start()
        {
            this.CardGenerator = this.transform.GetComponent<CardGenerator>();
        }


        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                this.SimulateDeepLinkSend();
            }
        }

        #endregion



        #region === Deep Link Methods ===

        private void SimulateDeepLinkSend()
        {
            string[] card = this.CardGenerator.Generate();

            string deepLink = this.GenerateDeepLink(card);

            this.DeepLinkManager.onDeepLinkActivated(deepLink);
        }
        

        private string GenerateDeepLink(string[] cardInfo)
        {
            // deep links have the form -> middl://middle_man?type/id/name

            string deepLink = DeepLink.Constants.DEEP_LINK_SCHEME + "://";
            deepLink += DeepLink.Constants.DEEP_LINK_HOST + "?";
            deepLink += cardInfo[0] + "/" + cardInfo[1] + "/" + cardInfo[2];

            return deepLink;
        }
        #endregion
    }
}
