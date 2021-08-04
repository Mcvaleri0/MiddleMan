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

        private AndroidJavaObject ActivityController { get; set; }
        private AndroidJavaObject PackageManager { get; set; }

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
                this.ActivityController = new AndroidJavaClass(Constants.UNITY_PLAYER_ID).GetStatic<AndroidJavaObject>(Constants.ACTIVITY);
                this.PackageManager = this.ActivityController.Call<AndroidJavaObject>(Constants.GET_PACKAGE_MANAGER);

                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        #endregion



        #region === Activity Methods ===
        
        public void GoToBackground()
        {
            //this.ActivityController.Call<bool>(Constants.TASK_TO_BACK, true);


            try
            {
                AndroidJavaObject launchIntent = this.PackageManager.Call<AndroidJavaObject>(Constants.GET_LAUNCH_INTENT, Constants.CHRONICLES_BUNDLE_ID);

                this.ActivityController.Call(Constants.START, launchIntent);

                launchIntent.Dispose();
            }
            catch (System.Exception)
            {
                Application.OpenURL("https://google.com");
            }
        }

        #endregion
    }
}
