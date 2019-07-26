using System;
using System.Security.Cryptography.X509Certificates;
using _UniverseAI.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;

namespace _UniverseAI.Scripts.Controllers
{
    public class ComponentIconController : MonoBehaviour
    {
        public GameObject toolTipObject;
        public GameObject labelNameObject;
        public GameObject labelVolumeObject;
        public GameObject labelSpriteObject;
        public String componentName;
        public String componentId;
        public String componentDescription;
        public ComponentModel componentModel;
        
        
        void start()
        {
            if (toolTipObject != null)
            {
                //On startup make sure all tooltips are not visible.
                toolTipObject.SetActive(false);
            }
        }

        public ComponentModel componentModel1
        {
            get => componentModel;
            set => componentModel = value;
        }

        public void SetName(String cName)
        {
            componentName = cName;
            UpdateObject();
        }

        public String GetName()
        {
            return componentName;
        }

        public void SetId(String id)
        {
            componentId = id;
            UpdateObject();
        }

        public String GetId()
        {
            return componentId;
        }

        public void SetDescription(String description)
        {
            componentDescription = description;
            UpdateObject();
        }

        public String GetDescription()
        {
            return componentDescription;
        }

        void UpdateObject()
        {
            labelNameObject.GetComponent<UILabel>().text = componentModel.componentName;
           labelVolumeObject.GetComponent<UILabel>().text = componentModel1.componentCubicVolume;
           GameObject toolTipLabel = toolTipObject.transform.GetChild (0).gameObject;
           toolTipLabel.GetComponent<UILabel>().text = componentModel1.componentDescription;
           Debug.Log("Child Object #1 " + labelNameObject.name);
        }

        void OnClick()
        {
            GameObject go;
            go = GameObject.Find("SecondaryGamePanel"); //TODO Sloppy Coding..need to clean up
            go.GetComponent<ComponentInventoryPanelController>().ButtonDisplayComponentInfo(componentModel);
            Debug.Log("Component " + componentName + " [" + componentId + "] clicked.");

        }
        
        void OnHover( bool isOver )
        {
            //ToolTip Check
            if (toolTipObject != null)
            {
                if (isOver)
                {
                    toolTipObject.SetActive(true);
                    Debug.Log("ToolTipActive");
                }
                else
                {
                    toolTipObject.SetActive(false);
                    Debug.Log("ToolTipDeactivated");
                }
          
            }
       
        }
    }
}