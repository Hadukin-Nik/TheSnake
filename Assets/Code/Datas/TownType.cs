using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Datas
{
    [CreateAssetMenu(fileName = "Town", menuName = "Data/Objects/NewTownType")]

    public sealed class TownType : ScriptableObject
    {   
        [Serializable]
        private struct randomBorders
        {
            public float _minInt;
            public float _maxInt;
        }
        [Serializable]
        private struct propertyOfTown
        {
            public randomBorders _bordersOfRandomValue;
            public string _pathToPropertyOfBonus;
        }

        [SerializeField] private Sprite _sprite;
        
        [SerializeField] private float _radiusCollaiderSize;

        [SerializeField] private List<propertyOfTown> _propertiesOfTown;
    }
}