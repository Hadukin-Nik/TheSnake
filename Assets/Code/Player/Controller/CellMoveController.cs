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

        public CellMoveController(Transform cell, Vector2 lastCellPosition)
        {
            _unit = cell;
            _rigidbody2D = cell.GetComponent<Rigidbody2D>();
            _queueOfCommands = new Queue<Vector2>();
        }
        public void AddMoveCommand(Vector2 moveDirection)
        {
            _queueOfCommands.Enqueue(moveDirection);
            _move(_queueOfCommands.Dequeue());
        }

        private void _move(Vector2 moveDirection)
        {
            Vector2 newCommandMove = _unit.position;
            _rigidbody2D.MovePosition(moveDirection);
            StepEvent.Invoke(newCommandMove);
        }

        
    }
}