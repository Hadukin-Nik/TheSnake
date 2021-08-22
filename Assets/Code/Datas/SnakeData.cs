using UnityEngine;

namespace Code.Datas
{
    [CreateAssetMenu(fileName = "SnakeData", menuName = "Data/Unit/SnakeData")]

    public sealed  class SnakeData : ScriptableObject
    {
        [SerializeField] private Sprite _spriteOfHead;

        [SerializeField] private Vector2 _startPosition;
        
        [SerializeField] private float _lengthOfStep;
        [SerializeField] private float _countOfStepsInSecond;
        
        
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
        
        public float LengthOfStep
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
    }
}