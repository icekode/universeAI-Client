using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using _UniverseAI.Scripts.Controllers;
using Proyecto26;
using UnityEditor;
using UnityEngine;
using _UniverseAI.Scripts.Misc;
using _UniverseAI.Scripts.Models;
using Vector3 = UnityEngine.Vector3;

namespace _UniverseAI.Scripts.Misc
{


// Function takes the ComponentModel data and creates a Base Icon Object 

    public class CreateComponentIcon : MonoBehaviour
    {
        // Start is called before the first frame update

        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        //********************************************************************************************************************
        //*************************************** PUBLIC METHODS *************************************************************
        //********************************************************************************************************************  

        public GameObject SpawnComponentObject(Vector3 position, GameObject prefab, GameObject parent, ComponentModel component)
        {
            GameObject tempGameObject = _HandleSpawnObject(position, prefab, parent, component);
            // Populate Icon
            tempGameObject.GetComponent<ComponentIconController>().SetId(component.componentID);
            tempGameObject.GetComponent<ComponentIconController>().SetName(component.componentName);

            return tempGameObject;
        }


        //********************************************************************************************************************
        //*************************************** PRIVATE METHODS *************************************************************
        //********************************************************************************************************************  


        private GameObject _HandleSpawnObject(Vector3 position, GameObject prefab, GameObject parent, ComponentModel component)
        {
            Debug.Log("Spawning new Object");
            GameObject newObject = NGUITools.AddChild(parent, prefab);
            newObject.transform.localPosition = position;
            newObject.name = "icon_" + component.componentName;
            return newObject;
        }
    }
}