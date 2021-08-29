using UnityEngine;

namespace Code.Interfaces
{
    public interface ISaveable
    {
        public GameObject MyGameObject { get; }
        public string GetYourType { get; }
    }
    
}