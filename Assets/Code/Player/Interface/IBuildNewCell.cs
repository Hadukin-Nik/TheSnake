using UnityEngine;

namespace Code.Player.Interface
{
    public interface IBuildNewCell
    {
        public IFollower CreateNewCell(Vector2 myPosition);
    }
}