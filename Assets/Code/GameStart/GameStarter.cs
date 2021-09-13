using System;
using Code.Controller;
using Code.Datas;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Initialization
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private MainData _mainData;

        private GameController _gameController;
        
        private Controllers _controllers;

        private SaveController _saveController;
        private void Start()
        {
            
            _controllers = new Controllers();
            gameObject.AddComponent<GameController>();
            if (TryGetComponent(out GameController gameController))
            {
                gameController.SetControllers(_controllers);
            }

            _saveController = new SaveController(_controllers, _mainData);
            _saveController.Load += CreateSceneParameters;
            CreateSceneParameters(gameObject.transform);
        }

        private void CreateSceneParameters(Transform tryLoad)
        {
            new GameInitialization(_controllers, _mainData, _saveController);

        }
    }
}