using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;



namespace Notifications
{
    public class NotificationsManager : MonoBehaviour
    {
        #region /* Instance */
        
        public static NotificationsManager Instance { get; private set; }

        #endregion



        #region === Unity Events ===

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
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
            this.CreateChannel();
        }


        // Update is called once per frame
        void Update()
        {

        }

        #endregion



        #region === Channel Methods ===
        
        private void CreateChannel()
        {
            AndroidNotificationChannel c = new AndroidNotificationChannel()
            {
                Id = Constants.CHANNEL_ID,
                Name = Constants.CHANNEL_NAME,
                Importance = Importance.High,
                Description = Constants.CHANNEL_DESCRIPTION,
            };
            AndroidNotificationCenter.RegisterNotificationChannel(c);
        }

        #endregion



        #region === Notifications Methods ===
        
        public void SendNotification(string cardType, string cardID)  {

            var notification = new AndroidNotification
            {
                Title = Constants.NOTIFICATION_TITLE,
                Text = cardType + ": " + cardID,
                FireTime = System.DateTime.Now,
                SmallIcon = Constants.NOTIFICATION_SMALL_ICON,
                LargeIcon = Constants.NOTIFICATION_LARGE_ICON
            };

            AndroidNotificationCenter.SendNotification(notification, Constants.CHANNEL_ID);
        }
        
        #endregion
    }
}
