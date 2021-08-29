using System;
using System.Collections.Generic;
using Code.Datas.Structures;
using UnityEngine;

namespace Code.Datas
{
    [CreateAssetMenu(fileName = "Town", menuName = "Data/Objects/NewTownType")]

    public sealed class TownTypeData : ScriptableObject
    {

        [SerializeField] private Sprite _sprite;
        
        [SerializeField] private List<TownDataProperty> _propertiesOfTown;

        [SerializeField] private string _nameOfTownType;
        
        [SerializeField] private float _radiusCollaiderSize;
        [SerializeField] private float _timeToDeathAfterDestroy;
        [SerializeField] private float _health;
        
        public Sprite Sprite
        {
            get
            {
                return _sprite;
            }
        }
        
        public List<TownDataProperty>  PropertiesOfTown
        {
            get
            {
                return _propertiesOfTown;
            }
        }
        
        public string NameOfTownType
        {
            get
            {
                return _nameOfTownType;
            }
        }
        
        public float RadiusCollaiderSize
        {
            get
            {
                return _radiusCollaiderSize;
            }
        }

        public float TimeToDeathAfterDestroy
        {
            get
            {
                return _timeToDeathAfterDestroy;
            }
        }

        public float Health
        {
            get
            {
                return _health;
            }
        }
    }
}