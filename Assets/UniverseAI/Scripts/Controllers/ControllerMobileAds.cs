namespace UniverseAI.Scripts.Controllers
{
    using UniverseAI.Scripts.General;
    using System;
    using UnityEngine;
    using GoogleMobileAds.Api;
    
    public class ControllerMobileAds : MonoBehaviour
    {
        public GameObject theBanner;
        
        public void Start()
        {
            // Initialize the Google Mobile Ads SDK.
           // MobileAds.Initialize(initStatus => { });
           
            #if UNITY_ANDROID
                string appId = "ca-app-pub-3940256099942544~3347511713";
            #elif UNITY_IPHONE
               string appId = "ca-app-pub-3940256099942544~1458002511";
            #else
               string appId = "unexpected_platform";
            #endif

           // Initialize the Google Mobile Ads SDK.
           MobileAds.Initialize(appId);
           theBanner.SetActive(true);
        }
    }
}