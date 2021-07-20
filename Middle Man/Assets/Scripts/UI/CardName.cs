using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace UI
{
    public class CardName : MonoBehaviour
    {
        #region /* Background Attributes */

        public RectTransform Background;
        
        #endregion



        #region === Unity Events ===

        // Start is called before the first frame update
        void Start()
        {
            this.SetBackgroundDimension();
        }

        // Update is called once per frame
        void Update()
        {
        }

        #endregion


        #region === Background Functions ===

        private void SetBackgroundDimension()
        {
            int height = (int)(0.1 * Screen.height);
            this.Background.sizeDelta = new Vector2(Screen.width, height);
        }
        #endregion


        #region === Text Functions ===
        #endregion
    }
}
