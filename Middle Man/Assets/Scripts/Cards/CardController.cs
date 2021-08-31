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
        
        public void Initialize(bool inAndroid)
        {
            if (Instance == null)
            {
                Instance = this;
                this.InitializeUI(inAndroid);

                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }


        #region == Auxiliar ==
        
        private void InitializeUI(bool inAndroid)
        {
            this.CardImage = this.transform.GetComponentInChildren<CardImage>();
            this.CardImage.Initialize();

            //this.CardName = this.transform.GetComponentInChildren<CardName>();
            //this.CardName.Initialize(inAndroid);

            this.OnSide = false;
        }

        #endregion

        #endregion



        #region === Information Methods ===

        public List<string> AllCardTypes()
        {
            List<string> types = new List<string>
            {
                Constants.CHARACTER_TYPE,
                Constants.EVIDENCE_TYPE,
                Constants.FORENSIC_TYPE,
                Constants.ITEM_TYPE,
                Constants.LOCATION_TYPE
            };

            return types;
        }


        public List<string> AllCardIDs(string type)
        {
            switch(type)
            {
                case Constants.CHARACTER_TYPE:
                    return this.GetCardIDs(Constants.CHARACTERS_IMAGES);

                case Constants.EVIDENCE_TYPE:
                    return this.GetCardIDs(Constants.EVIDENCES_IMAGES);

                case Constants.FORENSIC_TYPE:
                    return this.GetCardIDs(Constants.FORENSIC_IMAGES);

                case Constants.ITEM_TYPE:
                    return this.GetCardIDs(Constants.ITEMS_IMAGES);

                case Constants.LOCATION_TYPE:
                    return this.GetCardIDs(Constants.LOCATIONS_IMAGES);

                default:
                    throw new System.Exception(Constants.INVALID_TYPE_RECEIVED);
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
            string path;
            bool needsRotation = false;

            switch(type)
            {
                case Constants.CHARACTER_TYPE:
                    path = Constants.CHARACTERS_IMAGES;
                    break;

                case Constants.EVIDENCE_TYPE:
                    path = Constants.EVIDENCES_IMAGES;
                    break;

                case Constants.FORENSIC_TYPE:
                    path = Constants.FORENSIC_IMAGES;
                    needsRotation = true;
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

            this.LoadCard(path, name, needsRotation);
        }


        #region == Auxiliar ==

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

