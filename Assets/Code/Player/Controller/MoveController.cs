using System;
using Code.Interfaces;
using Code.Player.Interface;
using UnityEngine;

namespace Code.Controller
{
    public class MoveController : IMoveCommander, ILateExecute, ICleanup
    {
        public event Action<Vector2> StepEvent;

        private readonly SnakeContactsController _snake;
        private readonly IUnit _unitData;

        private Transform _unit;
        private Rigidbody2D _rigidbody2D;

        private IUserInput _horizontalInput;
        private IUserInput _verticalInput;

        private Vector3 _nextMove;
        private Vector3 _moveExecutable;


        private Vector3 _myPosition;
        private Vector3 _myLastPosition;
        
        
        private float _timeForStep;
        private float _timeFromLastStep;

        private bool _moveAccess;
        public MoveController((IUserInput inputHorizontal, IUserInput inputVertical) input, Transform unit,
            IUnit unitData)
        {
            _unit = unit;
            _unitData = unitData;
            _horizontalInput = input.inputHorizontal;
            _verticalInput = input.inputVertical;
            _horizontalInput.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInput.AxisOnChange += VerticalOnAxisOnChange;

            
            _snake =  unit.GetComponent<SnakeContactsController>();
            _snake._movePermission += MovePermission;
            
            
            _rigidbody2D = unit.GetComponent<Rigidbody2D>();

            _timeForStep = 1/_unitData.CountOfStepsInSecond ;
            _timeFromLastStep = 0;

            _moveExecutable = Vector2.zero;
            _nextMove = Vector2.zero;

            _moveAccess = true;
        }

        private void MovePermission(bool permission)
        {
            _moveAccess = permission;
        }
        
        private void VerticalOnAxisOnChange(float value)
        {
            if (_moveAccess)
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
                
        }

        private void HorizontalOnAxisOnChange(float value)
        {
            if (_moveAccess)
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
        }

        public void LateExecute(float deltaTime)
        {
            _timeFromLastStep -= deltaTime;
            if (_timeFromLastStep <= 0 && _moveAccess)
            {
                _timeFromLastStep = _timeForStep;
                if (_nextMove != Vector3.zero)
                {
                    _moveExecutable = _nextMove;
                }
                _rigidbody2D.MovePosition(_unit.position + _moveExecutable * _unitData.LengthStep);
                if (_myPosition != _unit.position)
                {
                    _myLastPosition = _myPosition;
                    _myPosition = _unit.position;
                    _snake.ChangeConstractionPlace(_myLastPosition);
                }
                StepEvent?.Invoke(_moveExecutable * _unitData.LengthStep);
            }
        }


        public void Cleanup()
        {
            _horizontalInput.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInput.AxisOnChange -= VerticalOnAxisOnChange;
        }


    }
}