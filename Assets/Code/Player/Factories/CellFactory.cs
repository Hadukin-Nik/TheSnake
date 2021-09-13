using Code.Controller;
using Code.Datas;
using Code.Player.Interface;
using Code.UnityExtentions;
using UnityEngine;

namespace Code.Player.Factories
{
    public class CellFactory: IBuildNewCell
    {
        private readonly SnakeData _snakeData;

        public CellFactory(SnakeData snakeData)
        {
            _snakeData = snakeData;
        }

        public IFollower CreateNewCell(Vector2 myPosition)
        {
            GameObject snakeCell = new GameObject(_snakeData.name).AddSprite(_snakeData.Sprite)
                .AddRigidbody2D(_snakeData.Mass).AddCircleCollider2D(_snakeData.Radius);
             Cell cell = snakeCell.GetOrAddComponent<Cell>();
             snakeCell.transform.position = myPosition;
            cell.Initialize();
            return cell;
        }
    }
}