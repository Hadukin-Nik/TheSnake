﻿using System;
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

        [SerializeField] private float _radiusCollaiderSize;

        
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
        
        public float RadiusCollaiderSize
        {
            get
            {
                return _radiusCollaiderSize;
            }
        }
    }
}