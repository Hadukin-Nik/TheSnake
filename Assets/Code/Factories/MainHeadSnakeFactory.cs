using System;
using Code.Datas;
using Code.Interfaces;
using Code.UnityExtentions;
using UnityEngine;

namespace Code.Controller
{
    public sealed class MainHeadSnakeFactory : ISnakeFactory
    {
        private Controllers _controllers;
        
        
        private readonly SnakeData _snakeData;

        private SnakeContactsController _snakeContactsController;

        private Action<bool> _movePermission;
        
        public MainHeadSnakeFactory(SnakeData snakeData, Controllers controllers)
        {
            _snakeData = snakeData;
            _controllers = controllers;
        }

        public Transform CreateSnakeHead()
        {
            GameObject snakeHead = new GameObject(_snakeData.name).AddSprite(_snakeData.Sprite)
                .AddRigidbody2D(_snakeData.Mass).AddCircleCollider2D(_snakeData.Radius);
            SnakeContactsController myLittleMonoBehaviour = snakeHead.GetOrAddComponent<SnakeContactsController>();
            myLittleMonoBehaviour.Initialise(_controllers, _snakeData.AttackForce, _snakeData.Health, _snakeData.CountOfStepsInSecond/1);
            return snakeHead.transform;
        }

    }
}