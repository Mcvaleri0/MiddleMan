using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

using UI;



namespace Cards
{
    public class CardController : MonoBehaviour
    {
        #region /* Instance */

        public static CardController Instance { get; private set; }

        #endregion

        #region /* UI Controllers */
        
        private CardImage CardImage { get; set; }
        private CardName CardName { get; set; }

        #region Auxiliar
        
        private bool OnSide { get; set; }
        
        #endregion

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
            this.CardImage = this.transform.GetComponentInChildren<CardImage>();
            this.CardName = this.transform.GetComponentInChildren<CardName>();

            this.OnSide = false;
        }


        // Update is called once per frame
        void Update()
        {

        }

        #endregion



        #region === Submit Cards ===
        
        public void SubmitCard(string type, string id, string name)
        {
            string path;
            bool needsRotation = false;

            switch(type)
            {
                case Constants.CHARACTER_TYPE:
                    path = Constants.CHARACTERS_IMAGES;
                    break;

                case Constants.EVIDENCE__TYPE:
                    path = Constants.EVIDENCES_IMAGES;
                    break;

                case Constants.FORENSIC_TYPE:
                    path = Constants.FORENSIC_IMAGES;
                    break;

                case Constants.ITEM_TYPE:
                    path = Constants.ITEMS_IMAGES;
                    break;

                case Constants.LOCATION_TYPE:
                    path = Constants.LOCATIONS_IMAGES;
                    needsRotation = true;
                    break;

                default:
                    throw new System.Exception(Constants.INVALID_TYPE_RECEIVED);
            }
            
            path = Path.Combine(path, id);

            Sprite image = Resources.Load<Sprite>(path);
            
            this.CardImage.SetCardImage(image);
            this.CardName.SetCardName(name);

            if (needsRotation && !this.OnSide)
            {
                this.CardImage.Rotate(90);
                this.OnSide = true;
            }
            else if (!needsRotation && this.OnSide)
            {
                this.CardImage.Rotate(-90);
                this.OnSide = false;
            }
        }
        
        #endregion
    }
}

