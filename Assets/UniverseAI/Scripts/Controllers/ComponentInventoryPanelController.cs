
using System;
using System.Collections.Generic;
using _UniverseAI.Scripts.Misc;
using _UniverseAI.Scripts.Models;
using UnityEngine.UI;
using UnityEngine;

namespace _UniverseAI.Scripts.Controllers
{
    public class ComponentInventoryPanelController : MonoBehaviour
    {
        public GameObject componentGrid;
        public GameObject iconPrefab;
        public IList<ComponentModel> mineralList;
        
        
        public GameObject informationContainer;
        public GameObject labelPrefab;

      
        
        void Awake()
        {
            
        }

        void Start()
        {
            this.GetComponent<LoadData>().LoadMineralsDataset();
        }

        void Update()
        {
            
        }

        public void RefreshMineralData(IList<ComponentModel> minerals)
        {
            mineralList = minerals;
            LoadIconsIntoGrid(); //TODO will need to remove all objects from grid and then readd
        }

        public void ButtonDisplayComponentInfo(ComponentModel item)
        {
            Debug.Log("This is mineral " + item.componentName + " [" + item.componentID + "]");
            updateInfoScreen(item);
        }
        
        public void updateInfoScreen(ComponentModel item)
        {
           informationContainer.GetComponent<ComponentInfoPanelController>().RefreshInfoPanel(item);

        }
        
        /**
         * Create Icons from List and populate into inventory grid.
         */
        private void LoadIconsIntoGrid()
        {
            foreach (ComponentModel mineral in mineralList)
            {
                GameObject newObject = NGUITools.AddChild(componentGrid, iconPrefab);
                newObject.transform.localPosition  =this.transform.position;
                newObject.name = "icon" + mineral.componentName;
                newObject.GetComponent<ComponentIconController>().componentModel1 = mineral;
                newObject.GetComponent<ComponentIconController>().SetId(mineral.componentID);
                newObject.GetComponent<ComponentIconController>().SetName(mineral.componentName);
            }
            
            //Reorder UIGrid
            componentGrid.GetComponent<UITable>().Reposition();
        }
    }
}