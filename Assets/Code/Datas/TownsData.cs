using System;
using System.Collections.Generic;
using Code.Datas.Structures;

using UnityEngine;

namespace Code.Datas
{
    [CreateAssetMenu(fileName = "MainTownsCreator", menuName = "Data/MainTownsCreator")]
    public sealed class TownsData : ScriptableObject
    {
        [SerializeField] private List<TownsDataContainer> _listOfTowns;

        public List<TownsDataContainer> ListOfTowns
        {
            get
            {
                return _listOfTowns;
            }
        }
    }
}