using System;
using Code.Datas.Managers;
using Code.Interfaces;
using UnityEngine;

namespace Code.GameLogicClasses.InputLogic
{
    public class PCInputLoad : IUserInput
    {
        public event Action<float> AxisOnChange = delegate(float f) { };
        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.GetKeyDown(AxisManager.LOADBUTTON) ? 1f : 0f);
        }
    }
}