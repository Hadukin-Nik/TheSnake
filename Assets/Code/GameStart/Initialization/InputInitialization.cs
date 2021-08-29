using Code.GameLogicClasses.InputLogic;
using Code.Interfaces;
using UnityEngine;

namespace Code.Controller
{
    internal sealed class InputInitialization
    {
        private IUserInput _pcInputHorizontal;
        private IUserInput _pcInputVertical;
        
        private IUserInput _pcInputSave;
        private IUserInput _pcInputLoad;


        public InputInitialization()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                
            }
            else
            {
                _pcInputHorizontal = new PCInputHorizontal();
                _pcInputVertical = new PCInputVertical();
                
                _pcInputSave = new PCInputSave();
                _pcInputLoad = new PCInputLoad();
            }
        }

        public (IUserInput inputHorizontal, IUserInput inputVertical, IUserInput inputSave, IUserInput inputLoad) GetInput()
        {
            (IUserInput inputHorizontal, IUserInput inputVertical, IUserInput inputSave, IUserInput inputLoad)
                resultInput = (_pcInputHorizontal, _pcInputVertical, _pcInputSave, _pcInputLoad);
            return resultInput;
        }

        public (IUserInput inputHorizontal, IUserInput inputVertical) GetInputForMovementOnly()
        {
            (IUserInput inputHorizontal, IUserInput inputVertical)
                resultInput = (_pcInputHorizontal, _pcInputVertical);
            return resultInput;
        }
        
        public (IUserInput inputSave, IUserInput inputLoad) GetInputForSavesOnly()
        {
            (IUserInput inputSave, IUserInput inputLoad)
                resultInput = (_pcInputSave, _pcInputLoad);
            return resultInput;
        }
    }
}