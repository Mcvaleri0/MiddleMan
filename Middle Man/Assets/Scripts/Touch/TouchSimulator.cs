using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Touch
{
    public class TouchSimulator : MonoBehaviour
    {
        #region /* Instance */

        public static TouchSimulator Instance { get; private set; }

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

        public void Initialize()
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

        #endregion



        #region === Game Actions ===
        
        public void EndInterrogation()
        {
            // TODO: simulate click in 'Goodbye' button
        }

        #endregion

    }
}
