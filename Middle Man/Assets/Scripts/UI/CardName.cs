using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




namespace UI
{
    public class CardName : MonoBehaviour
    {
        #region /* Text Attributes */
        
        private Text Name { get; set; }
        
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



        #region === Initialization ===
        
        public void Initialize(bool inAndroid)
        {
            this.Name = this.transform.GetComponentInChildren<Text>();

            int height = (int)(0.1 * Screen.height);

            this.SetBackgroundDimension(Screen.width, height);
            this.SetTextDimensions(Screen.width, height);

            var initalText = (inAndroid ? Constants.INITAL_CARD_TEXT : Constants.NOT_ANDROID_TEXT);
            this.SetCardName(initalText);
        }

        #endregion



        #region === Background Functions ===

        private void SetBackgroundDimension(int width, int height)
        {
            RectTransform background = this.transform.GetComponent<RectTransform>();

            background.sizeDelta = new Vector2(width, height);
        }
        #endregion


        #region === Text Functions ===

        private void SetTextDimensions(int width, int height)
        {
            RectTransform textBox = this.Name.transform.GetComponent<RectTransform>();
            textBox.sizeDelta = new Vector2(width, height);
        }


        public void SetCardName(string name)
        {
            this.Name.text = name;
        }

        #endregion
    }
}
