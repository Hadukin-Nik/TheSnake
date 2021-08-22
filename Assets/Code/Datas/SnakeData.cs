﻿using Code.Interfaces;
using UnityEngine;

namespace Code.Datas
{
    [CreateAssetMenu(fileName = "SnakeData", menuName = "Data/Unit/SnakeData")]

    public sealed  class SnakeData : ScriptableObject, IUnit
    {
        [SerializeField] private Sprite _spriteOfHead;

        [SerializeField] private Vector2 _startPosition = Vector2.zero;
        
        [SerializeField] private float _lengthOfStep;
        [SerializeField] private float _countOfStepsInSecond;

        [SerializeField] private float _mass;
        
        public Sprite Sprite
        {
            get
            {
                return _spriteOfHead;
            }
        }
        
        public Vector2 StartPosition
        {
            get
            {
                return _startPosition;
            }
        }
        
        public float LengthStep
        {
            get
            {
                return _lengthOfStep;
            }
        }
        
        public float CountOfStepsInSecond
        {
            get
            {
                return _countOfStepsInSecond;
            }
        }
        
        public float Mass
        {
            get
            {
                return _mass;
            }
        }
    }
}