using UnityEngine;

namespace UniverseAI.Scripts.Behaviours
{
    public class InfoTableRowBehaviour : MonoBehaviour
    {
        public GameObject toolTipObject;

        void start()
        {
            if (toolTipObject != null)
            {
                //On startup make sure all tooltips are not visible.
                toolTipObject.SetActive(false);
            }
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
