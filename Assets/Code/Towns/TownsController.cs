// using System;

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
    public class TownsController: ICleanup
    {
        private Controllers _controller;

        private TownsCreationController townsCreator;
        
        private int _countOfTowns = 0;
        public TownsController(Controllers controller, List<MainDataTownsInitialization.TownsContainers> townsInDataContainerOfLevel, List<List<bool>> cellUseage, 
            Vector2 sizeOfCell, float timeForNewTown, int maxTowns)
        {
            Debug.Log(townsInDataContainerOfLevel);
            _controller = controller;
            
            Dictionary<string, int> countOfCreatedTypesOfTowns = new Dictionary<string, int>();
            

            foreach (var townType in townsInDataContainerOfLevel)
            {
                countOfCreatedTypesOfTowns.Add(townType.TownType.NameOfTownType, 0);
            }
            
            CurrentTown[] a = Object.FindObjectsOfType<CurrentTown>();
            Debug.Log(a.Length);
            foreach (var town in a)
            {
                countOfCreatedTypesOfTowns[(town as ISaveable).GetYourType]++;
            }
             
            _countOfTowns++;

            townsCreator = new TownsCreationController(controller, countOfCreatedTypesOfTowns,
                townsInDataContainerOfLevel,
                cellUseage, sizeOfCell, timeForNewTown, maxTowns, a.Length);
            
            townsCreator.TownCreatedEvent += TownCreated;
            Debug.Log(townsCreator);
            _controller.Add(townsCreator);
        }

        
        
        private void TownCreated(string NameOfTownType)
        {
            _countOfTowns++;
        }

        private void TownDestroyed(string NameOfTownType)
        {
            _countOfTowns--;
        }

        public void Cleanup()
        {
            _controller.Delete(townsCreator);
        }
    }
}