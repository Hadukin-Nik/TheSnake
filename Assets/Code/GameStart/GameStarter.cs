using System;
using Code.Controller;
using Code.Datas;
using UnityEngine;

namespace Code.Initialization
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private MainData _mainData;

        private GameController _gameController;
        
        private Controllers _controllers;
        
        private void Start()
        {
            _controllers = new Controllers();
            _gameController = gameObject.AddComponent<GameController>();
            _gameController.SetControllers(_controllers);
        }
    }
}