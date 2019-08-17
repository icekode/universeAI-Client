using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using _UniverseAI.Scripts.Controllers;
using _UniverseAI.Scripts.Models;
using NodeCanvas.Framework;
using Proyecto26;
using UnityEngine;
using UniverseAI.Scripts.General;

namespace _UniverseAI.Scripts.Misc
{


    public class LoadData : MonoBehaviour
    {
        public GameObject authObject;
        [SerializeField] public String userToken;
        
        void Awake()
        {
            
        }

        void Start()
        {
           // userToken = globals.GetComponent<GlobalBlackboard>().
        }

        void Update()
        {
            
        }

        private string GetAuthToken()
        {
            var auth = authObject.GetComponent<GlobalBlackboard>().GetValue<string>("userToken");
            return auth;
        }
        
        /**
         * Load List of Minerals from Datastore
         */
        public void LoadMineralsDataset()
        {
            ComponentModel componentModel = new ComponentModel();
            IList<ComponentModel> componentList = new List<ComponentModel>();
            componentModel.componentType = "_mineral";

            var authToken = GetAuthToken();
            RestClient.Request(new RequestHelper
            {
                Uri = ConstantsUAI.FIRESTORE_API_PATH + "componentsLoadList",
                Method = "POST",
                Headers = new Dictionary<string, string> {
                    { "Authorization", authToken }
                },
                Body = componentModel
            }) .Then(response =>
            {
                ComponentModel[] componentArray = UAIJsonHelper.FromOutsideJson<ComponentModel>(response.Text);
                   
                //Convert Array to List
                foreach (var t in componentArray)
                {
                    componentList.Add(t);
                    Debug.Log("Adding Component " + t.componentName + ". Total components in list is " + componentList.Count);
                }
                this.GetComponent<ComponentInventoryPanelController>().RefreshMineralData(componentList);
            });
        }
    }
}