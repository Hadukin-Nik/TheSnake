using System;
using System.Collections.Generic;
using Code.Controller;
using Code.Interfaces;
using Code.UnityExtentions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Towns
{
    public class TownsController : IExecute
    {
        private ITownFactory _currentTownCreator;
        
        private List<MainDataTownsInitialization.TownsContainers> _townsData;
        private List<int> _countOfCreatedTownsOfType = new List<int>(1);
        
        private List<List<bool>> _cellUseage;

        private Vector2 _sizeOfLevel;
        private Vector2 _sizeOfCell;

        private float _timeForNewTownMax;
        private float _timeForNewTownNow;
        private int _countOfTowns;
        
        public TownsController(List<MainDataTownsInitialization.TownsContainers> townsInDataContainerOfLevel, Vector2 sizeOfLevel ,Vector2 sizeOfCell, float timeForNewTown)
        {
            _townsData = townsInDataContainerOfLevel;
            int countOfTypesTowns = townsInDataContainerOfLevel.Count;
            _countOfCreatedTownsOfType.Capacity = countOfTypesTowns;
           _countOfCreatedTownsOfType.InitialiseListByZero();

           _sizeOfLevel = sizeOfLevel;
           _sizeOfCell = sizeOfCell;
           
           _timeForNewTownMax = timeForNewTown;
           _timeForNewTownNow = 0f;
           
           CreateMap();
        }


        public void Execute(float deltaTime)
        {
            Debug.Log("Towns - ICanExecute!");
            if (_countOfTowns < _townsData.Count && _timeForNewTownNow <= 0f)
            {
                CreateRandomTown();
                _timeForNewTownNow = _timeForNewTownMax;
                _countOfTowns++;
            } 
        }

        private void CreateRandomTown()
        {
            int tryies = 0;
            int randomTown = Random.Range(0, _townsData.Count - 1);
            Debug.Log("Towns - CreateRandomTown - not");
            Debug.Log(_countOfCreatedTownsOfType.Count );
            Debug.Log(_townsData[randomTown].Count);
            
            if (_countOfCreatedTownsOfType[randomTown] > _townsData[randomTown].Count)
            {
                randomTown = Random.Range(0, _townsData.Count - 1);
                tryies++;
            } else if (tryies > _townsData[randomTown].Count * 2)
            {
                return;
                
            }
            Debug.Log("Towns - CreateRandomTown");
            _currentTownCreator = new TownFactory(_townsData[randomTown].TownType);
            var town = _currentTownCreator.CreateTown().gameObject.GetOrAddComponent<CurrentTown>();
            bool useablePlace = false;
            int x = 0, y = 0;
            while (!useablePlace)
            {
                x = Random.Range(0, _cellUseage[0].Count);
                y = Random.Range(0, _cellUseage.Count);

                if (!_cellUseage[y][x])
                {
                    useablePlace = true;
                    _cellUseage[y][x] = true;
                }
            }
            town.InitializeTown(new Vector2((float)x, (float)y) + _sizeOfCell);

            _countOfCreatedTownsOfType[randomTown]++;
        }

        private void CreateMap()
        {
            Debug.Log("Create map!");
            int townsCountByX = (int)Math.Floor(_sizeOfLevel.x / _sizeOfCell.x), townsCountByY = (int)Math.Floor(_sizeOfLevel.y / _sizeOfCell.y);
            _cellUseage = new List<List<bool>>();


            for (int i =0; i < townsCountByY; i++)
            {
                _cellUseage.Add(new List<bool>(townsCountByX));
            }
        }
    }
}