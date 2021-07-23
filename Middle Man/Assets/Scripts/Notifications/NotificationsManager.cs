using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;
using System;



namespace Notifications
{
    public class NotificationsManager : MonoBehaviour
    {
        #region /* Instance */
        
        public static NotificationsManager Instance { get; private set; }

        #endregion

        #region /* Notifications */
        
        private List<int> Notifications { get; set; }
        
        #endregion



        #region === Unity Events ===

        private void Awake()
        {
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
        
        public void Initialize()
        {
            if (Instance == null)
            {
                Instance = this;
                this.CreateChannel();
                this.Notifications = new List<int>();

                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        #endregion



        #region === Channel Methods ===

        private void CreateChannel()
        {
            AndroidNotificationChannel channel = new AndroidNotificationChannel()
            {
                Id = Constants.CHANNEL_ID,
                Name = Constants.CHANNEL_NAME,
                Importance = Importance.High,
                Description = Constants.CHANNEL_DESCRIPTION,
            };

            AndroidNotificationCenter.RegisterNotificationChannel(channel);
        }

        #endregion



        #region === Notifications Methods ===
        
        public void SendNotification(string cardType, string cardID)  {

            var notification = new AndroidNotification
            {
                Title = Constants.NOTIFICATION_TITLE,
                Text = cardType + ": " + cardID,
                FireTime = DateTime.Now,
                SmallIcon = Constants.NOTIFICATION_SMALL_ICON,
                LargeIcon = Constants.NOTIFICATION_LARGE_ICON
            };

            int notificationID = AndroidNotificationCenter.SendNotification(notification, Constants.CHANNEL_ID);

            this.Notifications.Add(notificationID);
        }


        public void CleanNotifications()
        {
            foreach (int notification in this.Notifications)
            {
                AndroidNotificationCenter.CancelNotification(notification);
            }

            this.Notifications.Clear();
        }
        
        #endregion
    }
}
