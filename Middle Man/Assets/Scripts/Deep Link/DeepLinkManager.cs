using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace DeepLink
{
    public class DeepLinkManager : MonoBehaviour
    {
        #region /* Instance and URL */

        public static DeepLinkManager Instance { get; private set; }
        
        public string DeepLinkURL;

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

        }

        // Update is called once per frame
        void Update()
        {

        }

        #endregion


        #region === Deep Link Methods ===

        private void onDeepLinkActivated(string url)
        {
            // Update DeepLink Manager global variable, so URL can be accessed from anywhere.
            this.DeepLinkURL = url;

            // Decode the URL to determine action. 
            // In this example, the app expects a link formatted like this:
            // unitydl://mylink?scene1
            string sceneName = url.Split("?"[0])[1];

            bool validScene;
            switch (sceneName)
            {
                case "scene1":
                    validScene = true;
                    break;
                case "scene2":
                    validScene = true;
                    break;
                default:
                    validScene = false;
                    break;
            }
        }

        #endregion
    }
}
