using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using _UniverseAI.Scripts.Controllers;
using _UniverseAI.Scripts.Models;
using Proyecto26;
using UnityEngine;

namespace _UniverseAI.Scripts.Misc
{


    public class LoadData : MonoBehaviour
    {
        
        
        void Awake()
        {
            
        }

        void Start()
        {
            
        }

        void Update()
        {
            
        }
        
        /**
         * Load List of Minerals from Datastore
         */
        public void LoadMineralsDataset()
        {
            ComponentModel componentModel = new ComponentModel();
            IList<ComponentModel> componentList = new List<ComponentModel>();
            componentModel.componentType = "_mineral";
            
            
            RestClient.Post("https://https://us-central1-projectuai.cloudfunctions.net/componentsLoadList", componentModel)
                .Then(response =>
                {
                   ComponentModel[] componentArray = UAIJsonHelper.FromOutsideJson<ComponentModel>(response.Text);
                   
                   //Convert Array to List
                   for (int count = 0; count < componentArray.Length; count++)
                   {
                       componentList.Add(componentArray[count]);
                       Debug.Log("Adding Component " + componentArray[count].componentName + ". Total components in list is " + componentList.Count);
                   }
                   this.GetComponent<ComponentInventoryPanelController>().RefreshMineralData(componentList);
                });
            
        }
    }
}