using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Notifications
{
    public static class Constants
    {
        #region /* Channel */

        public const string CHANNEL_ID = "Notifications";
        public const string CHANNEL_NAME = "Middle-Man Notifications";
        public const string CHANNEL_DESCRIPTION = "Notifies the cards received by the application 'Middle-Man'";

        #endregion


        #region /* Notification */

        public const string NOTIFICATION_TITLE = "Card Received";
        public const string NOTIFICATION_SMALL_ICON = "notifiy_small_icon";
        public const string NOTIFICATION_LARGE_ICON = "notifiy_large_icon";

        #endregion
    }
}
