﻿using Code.Datas;
using Code.Interfaces;
using Code.UnityExtentions;
using UnityEngine;

namespace Code.Controller
{
    public class TownFactory : ITownFactory
    {
        private readonly TownTypeData _town;

        public TownFactory(TownTypeData town)
        {
            _town = town;
        }
        public Transform CreateTown()
        {
            return new GameObject(_town.name).AddSprite(_town.Sprite)
                .AddCircleCollider2D(_town.RadiusCollaiderSize).AddRigidbody2D(0f).transform;
        }
    }
}