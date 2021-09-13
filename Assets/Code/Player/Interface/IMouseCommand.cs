using UnityEngine;

namespace Code.Player.Interface
{
    public interface IMouseCommand : ICell
    {
        public void MouseCommad(Vector2 mousePosition);
    }
}