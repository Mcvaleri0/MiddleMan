using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Cards
{
    public static class Constants
    {
        #region === Cards Types ===

        // make sure it is equal to the types sent by Alexa
        public const string CARD_TYPE_CHARACTER = "character";
        public const string CARD_TYPE_EVIDENCE = "evidence";
        public const string CARD_TYPE_FORENSIC = "forensic";
        public const string CARD_TYPE_ITEM = "special";
        public const string CARD_TYPE_LOCATION = "location";

        #endregion


        #region === Resources Path ===

        public enum PathTypes { ShowCodes, ShowImages }

        public const string CARDS_PATH = "Cards";
        public const string CODES_PATH = "Codes";
        public const string IMAGES_PATH = "Images";

        #endregion


        #region === Messages ===

        public const string INVALID_PATH_TYPE = "Invalid Path Type";
        
        #endregion
    }
}
