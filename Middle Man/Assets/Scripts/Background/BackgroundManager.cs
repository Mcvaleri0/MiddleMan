using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Notifications;
using DeepLink;



namespace Background
{
    public class BackgroundManager : MonoBehaviour
    {
        #region /* Instance */

        public static BackgroundManager Instance { get; private set; }

        #endregion

        #region /* Controllers */
        
        private DeepLinkManager DeepLinkManager { get; set; }
        
        #endregion



        #region === Unity Events ===

        // Start is called before the first frame update
        void Start()
        {

        }


        // Update is called once per frame
        void Update()
        {

        }


        private void OnApplicationPause(bool pause)
        {
            if (pause && 
               (!this.DeepLinkManager.DeepLinkURL.Equals(DeepLink.Constants.NO_DEEP_LINK)))
            {
                this.DeepLinkManager.ProcessDeepLink();
            }
        }

        #endregion



        #region === Initialization ===

        public void Initialize(DeepLinkManager deepLinkManager)
        {
            if (Instance == null)
            {
                Instance = this;
                this.DeepLinkManager = deepLinkManager;

                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        #endregion
    }
}
