using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Cards {
    public class CardGenerator : MonoBehaviour
    {
        #region /* Controllers */

        public CardController CardControler;
        
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

        #endregion


        #region === Card Methods ===
        
        public string[] Generate()
        {
            string[] card = new string[3];

            card[0] = this.GenerateCardType();
            card[1] = this.GenerateCardID(card[0]);
            card[2] = this.GenerateCardName();

            return card;
        }


        private string GenerateCardType()
        {
            List<string> types = this.CardControler.AllCardTypes();

            int index = Random.Range(0, types.Count);

            return types[index];
        }


        private string GenerateCardID(string type)
        {
            List<string> ids = this.CardControler.AllCardIDs(type);

            int index = Random.Range(0, ids.Count);

            return ids[index];
        }


        private string GenerateCardName()
        {
            return "Chief+Officer+Doyle";
        }
        
        #endregion
    }
}
