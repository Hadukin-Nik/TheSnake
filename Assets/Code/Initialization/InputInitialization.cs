using Code.GameLogicClasses.InputLogic;
using Code.Interfaces;
using UnityEngine;

namespace Code.Controller
{
    internal sealed class InputInitialization
    {
        private IUserInput _pcInputHorizontal;
        private IUserInput _pcInputVertical;

        public InputInitialization()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                
            }
            else
            {
                _pcInputHorizontal = new PCInputHorizontal();
                _pcInputVertical = new PCInputVertical();
            }
        }

        public (IUserInput inputHorizontal, IUserInput inputVertical) GetInput()
        {
            (IUserInput inputHorizontal, IUserInput inputVertical) resultInput = (_pcInputHorizontal, _pcInputVertical);
            return resultInput;
        }
    }
}