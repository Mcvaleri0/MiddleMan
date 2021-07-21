using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace UI
{
    public class CardImage : MonoBehaviour
    {
        #region /* Image Source */
        
        private RectTransform ImageBox { get; set; }
        private Image Card { get; set; }
        
        #endregion



        #region === Unity Events ===

        // Start is called before the first frame update
        void Start()
        {
            this.Card = this.transform.GetComponent<Image>();
            this.ImageBox = this.transform.GetComponent<RectTransform>();

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

            int height = (int)(0.9 * Screen.height);
            this.ImageBox.sizeDelta = new Vector2(Screen.width, height);

            int y = -(int)(0.05 * Screen.height);
            this.ImageBox.anchoredPosition = new Vector2(0, y);
        }

        #endregion



        #region === Set Methods ===
        
        public void SetCardImage(Sprite image) 
        {
            this.Card.sprite = image;
        }


        public void Rotate(float angle)
        {
            this.ImageBox.eulerAngles = new Vector3(0, 0, angle);

            float width = this.ImageBox.sizeDelta.x;
            float height = this.ImageBox.sizeDelta.y;

            this.ImageBox.sizeDelta = new Vector2(height, width);
        }
        
        #endregion
    }
}
