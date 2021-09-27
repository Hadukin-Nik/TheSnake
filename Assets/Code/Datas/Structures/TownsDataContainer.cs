using System;
using System.IO;
using UnityEngine;


namespace Code.Datas.Structures
{
    [Serializable]
    public sealed class TownsDataContainer 
    {

        [SerializeField] private string _nameOfTownType;
        [SerializeField] private int _count;

        private TownTypeData _town;

        public TownTypeData Town
        {
            get
            {
                if (_town == null)
                {
                    _town = Load<TownTypeData>("Data/Towns/" + _nameOfTownType);
                }

                return _town;
            }
        }
        
        
        public string NameOfTownType
        {
            get
            {
                return _nameOfTownType;
            }
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }
        private T Load<T>(string resourcesPath) where T : UnityEngine.Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}