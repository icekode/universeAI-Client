using System.Collections;
using System.Collections.Generic;
using _UniverseAI.Scripts.Models;
using UnityEngine;

public class ComponentInfoPanelController : MonoBehaviour
{
    public GameObject labelComponentId;
    public GameObject labelComponentName;
    public GameObject labelComponentDescription;
    public GameObject labelComponentCubicVolume;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshInfoPanel(ComponentModel item)
    {
        GameObject idValue = labelComponentId.transform.GetChild(0).gameObject;
        GameObject nameValue = labelComponentName.transform.GetChild(0).gameObject;
        GameObject descriptionValue = labelComponentDescription.transform.GetChild(0).gameObject;
        GameObject volumeValue = labelComponentCubicVolume.transform.GetChild(0).gameObject;

        idValue.GetComponent<UILabel>().text = item.componentID;
        nameValue.GetComponent<UILabel>().text = item.componentName;
        descriptionValue.GetComponent<UILabel>().text = item.componentDescription;
        volumeValue.GetComponent<UILabel>().text = item.componentCubicVolume;
        
        Debug.Log("Info panel refreshed.");
    }
}
