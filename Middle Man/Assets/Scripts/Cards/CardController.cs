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

        public Constants.PathTypes PathType;
        
        #endregion

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
                this.InitializeUI();

                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }


        #region == Auxiliar ==
        
        private void InitializeUI()
        {
            this.CardImage = this.transform.GetComponentInChildren<CardImage>();
            this.CardImage.Initialize(Instance);

            this.CardName = this.transform.GetComponentInChildren<CardName>();
            this.CardName.Initialize();

            this.OnSide = false;
        }

        #endregion

        #endregion



        #region === Information Methods ===
        // this methods no longer need to work

        public List<string> AllCardTypes()
        {
            List<string> types = new List<string>
            {
                //Constants.CHARACTER_TYPE,
                //Constants.EVIDENCE_TYPE,
                //Constants.FORENSIC_TYPE,
                //Constants.ITEM_TYPE,
                //Constants.LOCATION_TYPE
            };

            return types;
        }


        public List<string> AllCardIDs(string type)
        {
            switch(type)
            {
                //case Constants.CHARACTER_TYPE:
                //    return this.GetCardIDs(Constants.CHARACTERS_IMAGES);

                //case Constants.EVIDENCE_TYPE:
                //    return this.GetCardIDs(Constants.EVIDENCES_IMAGES);

                //case Constants.FORENSIC_TYPE:
                //    return this.GetCardIDs(Constants.FORENSIC_IMAGES);

                //case Constants.ITEM_TYPE:
                //    return this.GetCardIDs(Constants.ITEMS_IMAGES);

                //case Constants.LOCATION_TYPE:
                //    return this.GetCardIDs(Constants.LOCATIONS_IMAGES);

                default:
                    throw new System.Exception(Constants.INVALID_PATH_TYPE);
            };
        }


        #region == Auxiliar ==

        private List<string> GetCardIDs(string path)
        {
            List<string> ids = new List<string>();

            Object[] charsFiles = Resources.LoadAll(path);

            foreach (Object file in charsFiles)
            {
                ids.Add(file.name);
            }

            return ids;
        }

        #endregion

        #endregion



        #region === Submit Cards ===

        public void SubmitCard(string type, string id, string name)
        {
            bool needsRotation = false;

            if (this.PathType == Constants.PathTypes.ShowImages &&
               (type.Equals(Constants.CARD_TYPE_FORENSIC)) ||
               (type.Equals(Constants.CARD_TYPE_LOCATION)))
            {
                needsRotation = true;
            }

            string path = this.BuildCardPath(type, id);

            this.LoadCard(path, name, needsRotation);
        }


        #region == Auxiliar ==

        private string BuildCardPath(string cardType, string cardID)
        {
            var path = Path.Combine(Constants.CARDS_PATH, cardType);

            switch (this.PathType)
            {
                case Constants.PathTypes.ShowCodes:
                    path = Path.Combine(path, Constants.CODES_PATH);
                    break;

                case Constants.PathTypes.ShowImages:
                    path = Path.Combine(path, Constants.IMAGES_PATH);
                    break;

                default:
                    throw new System.Exception(Constants.INVALID_PATH_TYPE);
            }

            path = Path.Combine(path, cardID);

            return path;
        }


        private void LoadCard(string path, string name, bool rotated)
        {
            Sprite image = Resources.Load<Sprite>(path);

            this.CardImage.SetCardImage(image);
            this.CardName.SetCardName(name);

            if (rotated && !this.OnSide)
            {
                this.CardImage.Rotate(-90);
                this.OnSide = true;
            }
            else if (!rotated && this.OnSide)
            {
                this.CardImage.Rotate(0);
                this.OnSide = false;
            }
        }

        #endregion

        #endregion
    }
}

