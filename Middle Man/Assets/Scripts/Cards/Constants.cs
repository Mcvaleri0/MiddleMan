using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Cards
{
    public static class Constants
    {
        #region === Cards Types ===

        public const string CHARACTER_TYPE = "character";
        public const string EVIDENCE__TYPE = "evidence";
        public const string FORENSIC_TYPE = "forensic";
        public const string ITEM_TYPE = "special";
        public const string LOCATION_TYPE = "location";

        #endregion


        #region === Resources Path ===

        public const string CHARACTERS_IMAGES = "Characters/Images";
        public const string EVIDENCES_IMAGES = "Evidences/Images";
        public const string FORENSIC_IMAGES = "Forensic/Images";
        public const string ITEMS_IMAGES = "Items/Images";
        public const string LOCATIONS_IMAGES = "Locations/Images";

        #endregion


        #region === Messages ===

        public const string INVALID_TYPE_RECEIVED = "A card with an invalid type was received";
        
        #endregion
    }
}
