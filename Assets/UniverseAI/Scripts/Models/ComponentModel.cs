using System;

namespace _UniverseAI.Scripts.Models
{
    [Serializable]
    public class ComponentModel
    {
        public string componentID;
        public string componentType;
        public string componentName;
        public string componentDescription;
        public string componentCubicVolume;
        public string componentIsTest;
        public string componentIsRefinable;
        public string componentObjectReference;
        public string componentClassification;

        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);

        }
    }
}
