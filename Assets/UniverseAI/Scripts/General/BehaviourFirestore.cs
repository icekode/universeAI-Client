using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _UniverseAI.Scripts.Models;
using UniverseAI.Scripts.General;
using Proyecto26;

public class BehaviourFirestore 
{

    public void TestLoadMineral()
    {  
        ComponentModel mineral1 = new ComponentModel();
        mineral1.componentName = "Polyuthrthean";
        mineral1.componentCubicVolume = "0.01";
        mineral1.componentDescription =
            "Found in Veldspar, Concentrated Veldspar (5% more yield), Dense Veldspar (10% more)";
        mineral1.componentIsRefinable = "no";
        mineral1.componentIsTest = "yes";
        mineral1.componentType = "_mineral";
        mineral1.componentClassification = "MineralType";
        
        Debug.Log("Loading Test Mineral Starting.");
        
        RestClient.Post(ConstantsUAI.FIRESTORE_API_PATH + "componentsAddToDB", mineral1)
            .Then(response =>
            {
                Debug.Log("Added test component " + mineral1.componentName);
                Debug.Log("Response: " + response.ToString());
              
            });
    }
}
