using System;
using Code.Datas.Managers;
using Code.Interfaces;
using UnityEngine;

namespace Code.GameLogicClasses.InputLogic
{
    public class PCInputSave : IUserInput
    {
        public event Action<float> AxisOnChange = delegate(float f) { };
        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.GetKeyDown(AxisManager.SAVEBUTTON) ? 1f : 0f);
        }
    }
}