using UnityEngine;

namespace Code.Player.Interface
{
    public interface IMove
    {
        public void AddMoveCommand(Vector2 moveDirection);
    }
}