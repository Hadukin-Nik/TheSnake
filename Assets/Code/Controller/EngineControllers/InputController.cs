using Code.Interfaces;

namespace Code.Controller
{
    public sealed class InputController: ILateExecute
    {
        private readonly IUserInput _horizontal;
        private readonly IUserInput _vertical;

        public InputController((IUserInput inputHorizontal, IUserInput inputVertical) input)
        {
            _horizontal = input.inputHorizontal;
            _vertical = input.inputVertical;
        }
        
        public void LateExecute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
        }
    }
}