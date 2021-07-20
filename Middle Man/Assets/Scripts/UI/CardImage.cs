using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace UI
{
    public class CardImage : MonoBehaviour
    {
        #region /* Image Source */
        
        private Image Card { get; set; }
        
        #endregion



        #region === Unity Events ===

        // Start is called before the first frame update
        void Start()
        {
            this.Card = this.transform.GetComponent<Image>();

            this.SetImageDimension();
        }


        // Update is called once per frame
        void Update()
        {

        }

        #endregion



        #region === Initialization ===

        private void SetImageDimension()
        {
            RectTransform rect = this.transform.GetComponent<RectTransform>();

            int height = (int)(0.9 * Screen.height);
            rect.sizeDelta = new Vector2(Screen.width, height);

            int y = -(int)(0.05 * Screen.height);
            rect.anchoredPosition = new Vector2(0, y);
        }

        #endregion



        #region === Set Methods ===
        
        public void SetCardImage(Sprite image) 
        {
            this.Card.sprite = image;
        }
        
        #endregion
    }
}
