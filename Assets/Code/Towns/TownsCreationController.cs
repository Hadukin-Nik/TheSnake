using System;
using System.Collections.Generic;
using Code.Controller;
using Code.Interfaces;
using Code.UnityExtentions;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Code.Towns
{
    
    
    public class TownsCreationController: IExecute
    {
        private Controllers _controller;
        
        public event Action<string> TownCreatedEvent;
        

        private ITownFactory _currentTownCreator;

        private List<MainDataTownsInitialization.TownsContainers> _townsData;
        private Dictionary<string, int> _countOfCreatedTypesOfTowns;
        
        private List<List<bool>> _cellUseage;
        
        private Vector2 _sizeOfCell;
        
        private float _timeForNewTownMax;
        private float _timeForNewTownNow;
        private int _countOfTowns = 0;
        private int _maxTownsCount;

        public TownsCreationController(Controllers controller, Dictionary<string, int> countOfCreatedTypesOfTowns, 
            List<MainDataTownsInitialization.TownsContainers> townsInDataContainerOfLevel, List<List<bool>> cellUseage, 
            Vector2 sizeOfCell, float timeForNewTown, int maxTowns, int countOfTowns)
        {
            _controller = controller;
            _townsData = townsInDataContainerOfLevel;

            _countOfCreatedTypesOfTowns = countOfCreatedTypesOfTowns;
            
            _cellUseage = cellUseage;

            _sizeOfCell = sizeOfCell;
            
            _timeForNewTownMax = timeForNewTown;
            _timeForNewTownNow = 0f;
            _maxTownsCount = maxTowns;
            _countOfTowns = countOfTowns;

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
            Debug.Log(_countOfCreatedTypesOfTowns);
            if (_countOfCreatedTypesOfTowns[_townsData[randomTown].TownType.NameOfTownType] > _townsData[randomTown].Count)
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
            
            
            town.InitializeTown(_controller, resourcesAfterDeath, _townsData[randomTown].TownType,
                new Vector2((float)x, (float)y) + _sizeOfCell, _townsData[randomTown].TownType.NameOfTownType, 
                _townsData[randomTown].TownType.TimeToDeathAfterDestroy, _townsData[randomTown].TownType.Health);
            
            TownCreatedEvent.Invoke(_townsData[randomTown].TownType.NameOfTownType);
        }
    }
}