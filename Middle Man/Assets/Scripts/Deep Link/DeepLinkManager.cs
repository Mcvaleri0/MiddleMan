using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cards;
using Notifications;
using Background;



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
        private NotificationsManager NotificationsManager { get; set; }
        private BackgroundManager BackgroundManager { get; set; }

        #endregion



        #region === Unity Events ===

        private void Awake()
        {
            if (Instance == null)
            {
                this.InitializeSystem();

                if (!String.IsNullOrEmpty(Application.absoluteURL))
                {
                    // App initiated from deep link.
                    onDeepLinkActivated(Application.absoluteURL);
                }
                else
                {
                    // Initialize DeepLink Manager global variable.
                    this.DeepLinkURL = Constants.NO_DEEP_LINK;
                }

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
        }


        // Update is called once per frame
        void Update()
        {

        }

        #endregion


        #region === Initialization ===
        
        private void InitializeSystem()
        {
            this.Initialize();

            this.InitializeOtherControllers();

            this.BackgroundManager.GoToBackground();
        }


        #region == Auxiliar ==

        private void Initialize()
        {
            Instance = this;

            // Adds callback funtions for the deep links
            Application.deepLinkActivated += onDeepLinkActivated;
        }


        private void InitializeOtherControllers()
        {
            Transform card = GameObject.Find("Card").transform;
            this.CardController = card.GetComponent<CardController>();
            this.CardController.Initialize();

            Transform notify = GameObject.Find("NotificationManager").transform;
            this.NotificationsManager = notify.GetComponent<NotificationsManager>();
            this.NotificationsManager.Initialize();

            Transform background = GameObject.Find("BackgroundManager").transform;
            this.BackgroundManager = background.GetComponent<BackgroundManager>();
            this.BackgroundManager.Initialize(this);
        }

        #endregion

        #endregion



        #region === Deep Link Methods ===

        public void onDeepLinkActivated(string url)
        {
            // Update DeepLink Manager global variable, so URL can be accessed from anywhere.
            this.DeepLinkURL = url;

            this.BackgroundManager.GoToBackground();
        }


        public void ProcessDeepLink()
        {
            // Decode the URL to determine action. 
            // deep links have the form -> middl://middle_man?type/id/name
            string[] parameters = this.DeepLinkURL.Split('?')[1].Split('/');

            string cardType = parameters[0];
            string cardID = parameters[1];
            string cardName = this.CleanCardName(parameters[2]);

            this.CardController.SubmitCard(cardType, cardID, cardName);

            this.NotificationsManager.SendNotification(cardType, cardID);
        }


        #region == Auxilar ==

        private string CleanCardName(string nameDL)
        {
            // card name in deep link have the form -> Chief+Officer+Doyle
            string[] words = nameDL.Split('+');

            string cardName = "";
            foreach (string word in words)
            {
                cardName += ' ' + word;
            }

            return cardName;
        }
        
        #endregion

        #endregion
    }
}
