using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cards;



namespace DeepLink
{
    public class DeepLinkManager : MonoBehaviour
    {
        #region /* Instance and URL */

        public static DeepLinkManager Instance { get; private set; }
        
        public string DeepLinkURL;

        #endregion

        #region /* Controllers */

        private CardController CardController { get; set; }

        #endregion



        #region === Unity Events ===

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                Application.deepLinkActivated += onDeepLinkActivated;

                // Initialize DeepLink Manager global variable.
                this.DeepLinkURL = "[none]";

                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }


        // Start is called before the first frame update
        void Start()
        {
            Transform card = GameObject.Find("Card").transform;
            this.CardController = card.GetComponent<CardController>();
        }


        // Update is called once per frame
        void Update()
        {

        }

        #endregion


        #region === Deep Link Methods ===

        public void onDeepLinkActivated(string url)
        {
            // Update DeepLink Manager global variable, so URL can be accessed from anywhere.
            this.DeepLinkURL = url;

            // Decode the URL to determine action. 
            // deep links have the form -> middl://middle_man?type/id/name
            string[] parameters = url.Split("?"[0])[1].Split("/"[0]);

            string cardType = parameters[0];
            string cardID = parameters[1];
            string cardName = parameters[2];

            this.CardController.SubmitCard(cardType, cardID, cardName);
        }

        #endregion
    }
}
