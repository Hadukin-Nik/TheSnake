using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

namespace Code.Player.Interface
{
    public interface IFollower
    {
        public void NewMoveCommand(Vector2 moveCommandFromParent);
        public void ConstructCommand(IBuildNewCell newBuidOrder);
    }
}