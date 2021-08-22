using System;
using UnityEngine;

namespace Code.Datas.Structures
{
    [Serializable]
    public class TownDataProperty
    {
        [SerializeField] private string _nameOfBonus;
        [SerializeField] private randomBorders _randomBorders;
        
        [Serializable]
        private struct randomBorders
        {
            public float minInt;
            public float maxInt;
        }

        public string NameOfBonus
        {
            get
            {
                return _nameOfBonus;
            }
        }

        public (float left, float right) RandomBorders
        {
            get
            {
                (float left, float right) result = (_randomBorders.minInt, _randomBorders.maxInt);
                return result;
            }
        }
    }
}