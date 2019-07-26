using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneBehaviour : MonoBehaviour
{
    
    [SerializeField] public String currentScene;
    [SerializeField] public String previousScene;
  
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScene (String _newScene)
    {
       
        previousScene = currentScene;
        currentScene = _newScene;
   
    }

}
