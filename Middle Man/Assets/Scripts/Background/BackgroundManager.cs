using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Notifications;



namespace Background
{
    public class BackgroundManager : MonoBehaviour
    {
        #region /* Instance */

        public static BackgroundManager Instance { get; private set; }

        #endregion

        #region /* Controllers */
        
        private NotificationsManager Notifications { get; set; }
        
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
            if (pause)
            {
                this.Notifications.SendNotification("pause", "noice");
            }
        }

        #endregion



        #region === Initialization ===

        public void Initialize(NotificationsManager notificationsManager)
        {
            if (Instance == null)
            {
                Instance = this;
                this.Notifications = notificationsManager;

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
