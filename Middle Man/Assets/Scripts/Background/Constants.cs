using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Background
{
    public static class Constants
    {
        #region /* Activity Controller Parameters */

        public const string UNITY_PLAYER_ID = "com.unity3d.player.UnityPlayer";
        public const string ACTIVITY = "currentActivity";

        public const string CHRONICLES_BUNDLE_ID = "com.everydayiplay.scanandplay.coc";

        #endregion


        #region /* Java Functions for Call Methods */

        public const string TASK_TO_BACK = "moveTaskToBack";

        public const string GET_PACKAGE_MANAGER = "getPackageManager";
        public const string GET_LAUNCH_INTENT = "getLaunchIntentForPackage";
        public const string START = "startActivity";

        #endregion
    }
}
