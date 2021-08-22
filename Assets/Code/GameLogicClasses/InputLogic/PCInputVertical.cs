using System;
using Code.Datas.Managers;
using Code.Interfaces;
using UnityEngine;

namespace Code.GameLogicClasses.InputLogic
{
    public sealed class PCInputVertical : IUserInput
    {
        public event Action<float> axisOnChange = delegate(float f) { };

        public void GetAxis()
        {
            axisOnChange.Invoke((Input.GetAxis(AxisManager.VERTICAL)));
        }
    }
}