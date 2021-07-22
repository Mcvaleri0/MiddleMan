using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace UI
{
    public class ExitButton : MonoBehaviour
    {
        #region === Unity Events ===

        // Start is called before the first frame update
        void Start()
        {
            this.SetButtonPosition();
        }

        // Update is called once per frame
        void Update()
        {

        }

        #endregion


        #region === UI Methods ===
        
        private void SetButtonPosition()
        {
            RectTransform buttonBox = this.transform.GetComponent<RectTransform>();
            float width = buttonBox.sizeDelta.x;
            float height = buttonBox.sizeDelta.y;

            float x = Screen.width - width - 10 ;
            float y = - (0.1f * Screen.height) - 10;

            buttonBox.anchoredPosition = new Vector2(x, y);
        }

        #endregion


        #region === Button Functions ===
        
        public void CloseApp()
        {
            Application.Quit();
        }
        
        #endregion
    }

}
