// using System;

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
        private Controllers _controllers;
        
        
        private ITownFactory _currentTownCreator;

        private List<MainDataTownsInitialization.TownsContainers> _townsData;
        private List<int> _countOfCreatedTypesOfTowns;
        
        private List<List<bool>> _cellUseage;

        private Action _townDestroyed;
        
        private Vector2 _sizeOfCell;
        
        private float _timeForNewTownMax;
        private float _timeForNewTownNow;
        
        private int _countOfTowns;
        private int _maxTownsCount;
        
        public TownsController(Controllers controllers, List<MainDataTownsInitialization.TownsContainers> townsInDataContainerOfLevel, List<List<bool>> cellUseage, Vector2 sizeOfCell, float timeForNewTown, int maxTowns)
        {
            _controllers = controllers;
            
            
            _townsData = townsInDataContainerOfLevel;
            int countOfTypesTowns = townsInDataContainerOfLevel.Count;
            _countOfCreatedTypesOfTowns = new List<int>(countOfTypesTowns);
            _cellUseage = cellUseage;
            
            _countOfCreatedTypesOfTowns.InitialiseListByZero();
            _countOfTowns = 0;
            
            _sizeOfCell = sizeOfCell;
            
            _timeForNewTownMax = timeForNewTown;
            _timeForNewTownNow = 0f;
            _maxTownsCount = maxTowns;
        }


        public void Execute(float deltaTime)
        {
            if (_countOfTowns < _maxTownsCount && _timeForNewTownNow <= 0f)
            {
                CreateRandomTown();

                _timeForNewTownNow = _timeForNewTownMax;
                _countOfTowns++;
            }
            
            _timeForNewTownNow -= deltaTime;
        }

        private void CreateRandomTown()
        {
            int tryies = 0;
            int randomTown = Random.Range(0, _townsData.Count );

            if (_countOfCreatedTypesOfTowns[randomTown] > _townsData[randomTown].Count)
            {
                randomTown = Random.Range(0, _townsData.Count - 1);
                tryies++;
            } else if (tryies > _townsData[randomTown].Count * 2)
            {
                return;
                
            }

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

            ResourceHeapCreator resourcesAfterDeath = new ResourceHeapCreator(_townsData[randomTown].TownType.RadiusCollaiderSize);
            town.InitializeTown(resourcesAfterDeath, DeleteTownFromControllers, _townsData[randomTown].TownType, new Vector2((float)x, (float)y) + _sizeOfCell, _townsData[randomTown].TownType.TimeToDeathAfterDestroy, _townsData[randomTown].TownType.Health);
            _controllers.Add(town);
            _countOfCreatedTypesOfTowns[randomTown]++;
        }

        private void DeleteTownFromControllers(CurrentTown town)
        {
            _controllers.Delete(town);
        }
    }
}