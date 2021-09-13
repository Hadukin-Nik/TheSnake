using System;
using UnityEngine;

namespace Code.Player.Interface
{
    public interface IMoveCommander : ICell
    {
        public event Action<Vector2> StepEvent;
    }
}