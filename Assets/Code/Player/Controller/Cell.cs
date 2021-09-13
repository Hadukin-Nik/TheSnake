using System;
using System.Collections.Generic;
using Code.Player.Interface;
using UnityEngine;

namespace Code.Controller
{
    public class Cell : MonoBehaviour, IFollower
    {
        private Vector2 _myLastPosition;
        private Vector2 _myPresentPosition;

        private float _healthPoints;
        
        private IMove _moveMe;
        private IMoveCommander _moveCommander;

        private bool _contructNeeded = false;
        private bool _constructPossible = true;
        private IBuildNewCell _buildNewCellCommand;

        private IFollower _myFollower;
        private bool _IHaveFollower = false;
        public void Initialize()
        {
            CellMoveController cellMoveController = new CellMoveController(transform);
            _moveMe = cellMoveController;
            _moveCommander = cellMoveController;

            _moveCommander.StepEvent += DoSomethingOnMove;
            
            _myPresentPosition = transform.position;
        }


        public void NewMoveCommand(Vector2 moveCommandFromParent)
        {
            _moveMe.AddMoveCommand(moveCommandFromParent);
        }

        public void DoSomethingOnMove(Vector2 moveDirection)
        {
            if (_myPresentPosition != (Vector2)transform.position)
            {
                _myLastPosition = _myPresentPosition;
                _myPresentPosition = transform.position;
            }
            if (_contructNeeded && _constructPossible)
            {
                _myFollower = _buildNewCellCommand.CreateNewCell(_myLastPosition);
                _IHaveFollower = true;

                _constructPossible = false;
                _contructNeeded = false;
            }

            if (_IHaveFollower)
            {
                _myFollower.NewMoveCommand(moveDirection);
            }
        }

        public void ConstructCommand(IBuildNewCell newBuidOrder)
        {
            if (!_constructPossible)
            {
                _myFollower.ConstructCommand(newBuidOrder);
            }
            else
            {
                _buildNewCellCommand = newBuidOrder;
                _contructNeeded = true;
            }

        } 
    }
}