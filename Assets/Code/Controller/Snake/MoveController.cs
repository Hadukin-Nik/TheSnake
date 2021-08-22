using Code.Interfaces;
using UnityEngine;

namespace Code.Controller
{
    public class MoveController : ILateExecute, ICleanup
    {
        private readonly IUnit _unitData;

        private Transform _unit;
        private Rigidbody2D _rigidbody2D;

        private IUserInput _horizontalInput;
        private IUserInput _verticalInput;

        private Vector3 _nextMove;
        private Vector3 _moveExecutable;

        private float _horizontal;
        private float _vertical;

        private float _timeForStep;
        private float _timeFromLastStep;


        public MoveController((IUserInput inputHorizontal, IUserInput inputVertical) input, Transform unit,
            IUnit unitData)
        {
            _unit = unit;
            _unitData = unitData;
            _horizontalInput = input.inputHorizontal;
            _verticalInput = input.inputVertical;
            _horizontalInput.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInput.AxisOnChange += VerticalOnAxisOnChange;

            _rigidbody2D = unit.GetComponent<Rigidbody2D>();

            _timeForStep = 1/_unitData.CountOfStepsInSecond ;
            _timeFromLastStep = 0;

            _moveExecutable = Vector2.zero;
            _nextMove = Vector2.zero;
        }

        private void VerticalOnAxisOnChange(float value)
        {
            if (value < 0)
            {
                _nextMove = Vector2.down;
            }
            else if (value > 0)
            {
                _nextMove = Vector2.up;
            }
        }

        private void HorizontalOnAxisOnChange(float value)
        {
            if (value < 0)
            {
                _nextMove = Vector2.left;
            }
            else if (value > 0)
            {
                _nextMove = Vector2.right;
            }
        }

        public void LateExecute(float deltaTime)
        {
            _timeFromLastStep -= deltaTime;
            if (_timeFromLastStep <= 0)
            {
                _timeFromLastStep = _timeForStep;
                if (_nextMove != Vector3.zero)
                {
                    _moveExecutable = _nextMove;
                }
                _rigidbody2D.MovePosition(_unit.position + _moveExecutable *_unitData.LengthStep);
            }
        }


        public void Cleanup()
        {
            _horizontalInput.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInput.AxisOnChange -= VerticalOnAxisOnChange;
        }

    }
}