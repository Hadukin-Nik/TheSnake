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
            gameObject.AddComponent<GameController>();
            if (TryGetComponent(out GameController gameController))
            {
                gameController.SetControllers(_controllers);
            }
            new GameInitialization(_controllers, _mainData);
        }
    }
}