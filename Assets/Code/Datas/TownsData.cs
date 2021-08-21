using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Datas
{
    [CreateAssetMenu(fileName = "SnakeData", menuName = "Data/Objects/MainTownsCreator")]
    public sealed class TownsData : ScriptableObject
    {
        [Serializable]
        private struct Town
        {
            public string pathToTownType;
            
            public int count;
        }

        [SerializeField] private List<Town> _listOfTowns;
    }
}