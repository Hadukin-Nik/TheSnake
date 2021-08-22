using Code.Datas;
using Code.Interfaces;
using Code.UnityExtentions;
using UnityEngine;

namespace Code.Controller
{
    public sealed class MainHeadSnakeFactory : ISnakeFactory
    {
        private readonly SnakeData _snakeData;

        public MainHeadSnakeFactory(SnakeData snakeData)
        {
            _snakeData = snakeData;
        }

        public Transform CreateSnakePart()
        {
            return new GameObject(_snakeData.name).AddSprite(_snakeData.Sprite)
                .AddBoxCollider2D().transform;        
        }
    }
}