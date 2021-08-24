using System.Collections.Generic;
using Code.Datas;
using Code.Datas.Structures;
using Code.Interfaces;
using UnityEngine;

namespace Code.Controller
{
    public sealed  class MainDataTownsInitialization : ITownsMainInformation
    {
        public sealed class TownsContainers
        {
            public int Count;
            private TownTypeData _townTypeData;

            public TownsContainers(TownTypeData townTypeData, int count)
            {
                _townTypeData = townTypeData;
                Count = count;
            }
            
            public TownTypeData TownType
            {
                get
                {
                    return _townTypeData;
                }
            }
            
        }
        private readonly List<TownsContainers> _towns;

        public MainDataTownsInitialization(TownsData townsData)
        {
            _towns = new List<TownsContainers>();
            Debug.Log(townsData.ListOfTowns.Count);
            foreach (var town in townsData.ListOfTowns)
            {
                _towns.Add(new TownsContainers(town.Town, town.Count));
            }
            Debug.Log(_towns.Count);
        }

        public List<TownsContainers> GetListOfTownsOnLevel()
        {
            return _towns;
        }
    }
}