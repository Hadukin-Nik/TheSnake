using System;
using System.Collections.Generic;
using System.IO;
using Code.Controller;
using Code.Datas;
using Code.Datas.Structures;
using Code.Interfaces;
using Code.Towns;
using Code.UnityExtentions;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Savers
{
    public class SaveDataRepository
    {
        private Controllers _controller;

        private Action _sceneLoad;
        private Action _sceneSave;
        
        private readonly MainData _mainData;
        
        private readonly IData<SavedData> _data;
        private readonly TownsData _townsData;
        private TownFactory _townFactory;
        
        
        private const string _folderName = "dataSave";

        private Dictionary<string, TownTypeData> townsTypes;
        
        private string _fileName = "data.bat";
        private readonly string _path;

        public SaveDataRepository(Controllers controller, ISaver saver, MainData mainData, TownsData townsData)
        {
            townsTypes = new Dictionary<string, TownTypeData>();
            

            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                Debug.LogError("Not useable platform for saves");
            }
            else
            {
                _data = new JsonData<SavedData>();
            }
            _path = Path.Combine(Application.dataPath, _folderName);

            _controller = controller;
            _mainData = mainData;
            _townsData = townsData;

            saver.Load += Load;
            saver.Save += Save;
            
            foreach (var townDataContainer in _townsData.ListOfTowns)
            {
                townsTypes.Add(townDataContainer.NameOfTownType, townDataContainer.Town);
            }
        }


        public void Save(Transform snake, List<TownOnLoadData> towns)
        {
            Debug.Log(towns.Count);
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }

            var saveData = new SavedData
            {
                Name = "Player Name",

                PlayerPosition = (Vector2) snake.gameObject.transform.position,

                TownsOnScene = towns
            };
            
            _data.Save(saveData, Path.Combine(_path, _fileName));

            
        }

        public void Load(Transform snake)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file)) return;
            var savedData = _data.Load(file);
            snake.transform.position = (Vector2)savedData.PlayerPosition;
            snake.name = savedData.Name;

            List<TownOnLoadData> towns = savedData.TownsOnScene;
            

            CurrentTown[] destroyableTowns = Object.FindObjectsOfType(typeof(CurrentTown)) as CurrentTown[];
            foreach (var townForDestroy in destroyableTowns)
            {
                if (townForDestroy is ICleanup destroy)
                {
                    destroy.Cleanup();
                }
            }
            
            
            foreach (var town in towns)
            {
                Debug.Log(town.TownType);
                _townFactory = new TownFactory(townsTypes[town.TownType]);
                
                var CreatingTown = _townFactory.CreateTown().gameObject.GetOrAddComponent<CurrentTown>();

                ResourceHeapCreator resourcesAfterDeath = new ResourceHeapCreator(townsTypes[town.TownType].RadiusCollaiderSize);
                 CreatingTown.InitializeTown(_controller, resourcesAfterDeath, townsTypes[town.TownType],
                                town.PlaceOfTown,townsTypes[town.TownType].NameOfTownType ,townsTypes[town.TownType].TimeToDeathAfterDestroy, townsTypes[town.TownType].Health);
            }
            _controller.DestroyAllExcludingInitialization();
            // new GameInitializationOnLoad(_mainData, _controller, snake);
        }

    }
}