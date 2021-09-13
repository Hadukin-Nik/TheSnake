using System;
using System.Collections.Generic;
using Code.Interfaces;
using Code.Player.Interface;
using UnityEngine;

namespace Code.Controller
{
    public class CellMoveController : IMoveCommander, IMove
    {
        public event Action<Vector2> StepEvent = Vector2 => { };

        private Transform _unit;
        private Rigidbody2D _rigidbody2D;
        
        private Queue<Vector2> _queueOfCommands;

        public CellMoveController(Transform cell)
        {
            _rigidbody2D = cell.GetComponent<Rigidbody2D>();
            _queueOfCommands = new Queue<Vector2>();
            _queueOfCommands.Enqueue(Vector2.zero);
        }
        public void AddMoveCommand(Vector2 moveDirection)
        {
            _queueOfCommands.Enqueue(moveDirection);
            _move(_queueOfCommands.Dequeue());
        }

        private void _move(Vector2 moveDirection)
        {
            
            _rigidbody2D.MovePosition(moveDirection);
            StepEvent.Invoke(moveDirection);
        }

        
    }
}