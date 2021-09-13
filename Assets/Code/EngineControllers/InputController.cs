using Code.Interfaces;

namespace Code.Controller
{
    public sealed class InputController: ILateExecute
    {
        private readonly IUserInput _horizontal;
        private readonly IUserInput _vertical;
        
        private readonly IUserInput _saveInput;
        private readonly IUserInput _loadInput;

        public InputController((IUserInput inputHorizontal, IUserInput inputVertical, IUserInput inputSave, IUserInput inputLoad) input)
        {
            _horizontal = input.inputHorizontal;
            _vertical = input.inputVertical;

            _saveInput = input.inputSave;
            _loadInput = input.inputLoad;
        }
        
        public void LateExecute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
            
            _saveInput.GetAxis();
            _loadInput.GetAxis();
        }
    }
}