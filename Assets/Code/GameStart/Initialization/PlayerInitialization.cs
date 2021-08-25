using System;
using Code.Interfaces;
using UnityEngine;

namespace Code.Controller
{
    public class PlayerInitialization
    {
        private readonly ISnakeFactory _playerFactory;
        private Transform _player;

        public PlayerInitialization(ISnakeFactory playerFactory, Vector2 positionPlayer)
        {
            _playerFactory = playerFactory;
            _player = _playerFactory.CreateSnakeHead();
            _player.position = positionPlayer;
        }

        public Transform GetPlayer()
        {
            return _player;
        }
    }
}