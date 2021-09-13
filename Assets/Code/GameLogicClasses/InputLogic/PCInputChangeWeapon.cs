using System;
using Code.Datas.Managers;
using Code.Interfaces;
using UnityEngine;

namespace Code.GameLogicClasses.InputLogic
{
    public class PCInputChangeWeapon : IUserInput
    {
        public event Action<float> AxisOnChange = delegate(float f) {  };
        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.GetMouseButtonUp(1)? 1.0f : 0.0f);
        }
    }
}