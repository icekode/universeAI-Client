using System;
using System.Collections;
using System.Collections.Generic;
using NodeCanvas.Framework;
using UnityEngine;

public class MainGameController : MonoBehaviour
{
    public GameObject subMenuAdminPanel;

    void Awake()
    {
        ResetMenus();
    }
    
    // Start is called before the first frame update
    void Start()
    {
      //  DisablePanels();
      // Various scenes gameControlMenu, mainControlMenu, authenticationMenu
      gameObject.GetComponent<GameSceneBehaviour>().changeScene("authenticationMenu");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    public void ButtonTestCrashlytics()
    {
        throw new System.Exception("test exception please ignore");
    }

    public void ButtonTestMineralLoad()
    {
        BehaviourFirestore dbTest = new BehaviourFirestore();
        
        dbTest.TestLoadMineral();
    }

    public void ButtonExitApp()
    {
        Debug.Log("Quitting Application");
        Application.Quit();
    }

    public void buttonMainPanel()
    {
        //DisablePanels();
        gameObject.GetComponent<GameSceneBehaviour>().changeScene("mainControlMenu");
        Debug.Log("Activate Main Control Panel.");
    }

    public void ButtonGameControlPanel()
    {
        gameObject.GetComponent<GameSceneBehaviour>().changeScene("gameControlMenu");
       // this.GetComponent<Blackboard>().SetValue("currentScene", "gameControlMenu");
    
        Debug.Log("Activate Main Control Panel.");
    }

    private void DisablePanels()
    {
        Debug.Log("Disabling all Panels");
      
    }

    public void ButtonToggleAdminPanel()
    {
        ToggelPanel(subMenuAdminPanel);
        Debug.Log( "Toggle Admin Panel");
    }

    private void ToggelPanel(GameObject _panel)
    {
        if (_panel.activeSelf) {_panel.SetActive(false);} else {_panel.SetActive(true);}
    }

    private void ResetMenus()
    {
        Debug.Log("Disabling Menu Views");
        GameObject[] menus;
        
        menus = GameObject.FindGameObjectsWithTag("MenuPanel");

        foreach (GameObject menu in menus)
        {
            menu.SetActive(false);
            
        }
    }
}
