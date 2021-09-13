using System;
using Code.Interfaces;
using UnityEngine;

namespace Code.GameLogicClasses.InputLogic
{
    public class PCInputUseWeapon: IUserInput
    {
        public event Action<float> AxisOnChange = delegate(float f) {  };
        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.GetMouseButtonUp(0) ? 1.0f : 0.0f);
        }
    }
}