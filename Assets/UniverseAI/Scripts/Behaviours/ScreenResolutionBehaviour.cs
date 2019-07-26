using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace UniverseAI
{
    /**
     * Set Default Screen Resolution
     */
    public class ScreenResolutionBehaviour : MonoBehaviour
    {

        public int screenWidth;
        public int screenHeight;

        public GameObject uIRoot;

        // Use this for initialization
        void Start()
        {
            ConfigureScreenSize();
            InitScreen();
        }

        void InitScreen()
        {
            Screen.autorotateToPortrait = false;
            Screen.autorotateToPortraitUpsideDown = false;
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            Screen.autorotateToLandscapeLeft = true;
            Screen.autorotateToLandscapeRight = true;
            uIRoot.GetComponent<UIRoot>().scalingStyle = UIRoot.Scaling.Constrained;
            uIRoot.GetComponent<UIRoot>().manualWidth = screenWidth;
            uIRoot.GetComponent<UIRoot>().manualHeight = screenHeight;

            Debug.LogFormat("Forcing Screen Resolution width:{0} height:{1}", screenWidth, screenHeight);

        }

        void ConfigureScreenSize()
        {
            #if UNITY_STANDALONE
                screenWidth = 1400;
                screenHeight = 900;
                Debug.Log("Activating UNITY_STANDALONE mode. [" + screenWidth + "/" + screenHeight + "]");
            #endif
        }
    }
}

