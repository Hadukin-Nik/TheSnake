using System;
using System.Collections.Generic;
using Code.Datas.Managers;
using UnityEngine;

namespace Code.Datas
{
    [CreateAssetMenu(fileName =  "ButtonsData", menuName = "Data/Data")]
    public class ButtonsData : ScriptableObject
    {
        [SerializeField] private List<ButtonData> _buttonsInformation = new List<ButtonData>();

        public List<ButtonData> ButtonsInformation
        {
            get
            {
                return _buttonsInformation;
            }
        }
    }

    [Serializable]
    public class ButtonData
    {
        

        public ButtonType ButtonType;
        public string ButtonName;
        public Sprite Sprite;
        public Vector3 Position;
        public Vector3 Size;
    }

}