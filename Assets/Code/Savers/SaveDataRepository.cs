using System.Collections.Generic;
using System.IO;
using Code.Controller;
using Code.Datas;
using Code.Datas.Structures;
using Code.Interfaces;
using Code.Towns;
using Code.UnityExtentions;
using UnityEngine;

namespace Code.Savers
{
    public class SaveDataRepository
    {
        private Controllers _controller;
        
        
        private readonly IData<SavedData> _data;
        private readonly TownsData _townsData;
        private TownFactory _townFactory;
        
        
        private const string _folderName = "dataSave";

        private Dictionary<string, TownTypeData> townsTypes;
        
        private string _fileName = "data.bat";
        private readonly string _path;

        public SaveDataRepository(Controllers controller, TownsData townsData)
        {
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
            _townsData = townsData;
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

            townsTypes = new Dictionary<string, TownTypeData>();
            
            foreach (var townDataContainer in _townsData.ListOfTowns)
            {
                TownsDataContainer town = townDataContainer as TownsDataContainer;
                townsTypes.Add(townDataContainer.NameOfTownType, town.Town);
            }
        }

        public void Load(Transform snake)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file)) return;
            var newPlayer = _data.Load(file);
            snake.transform.position = (Vector2)newPlayer.PlayerPosition;
            snake.name = newPlayer.Name;

            List<TownOnLoadData> towns = newPlayer.TownsOnScene;
            

            CurrentTown[] destroyableTowns = Object.FindObjectsOfType(typeof(CurrentTown)) as CurrentTown[];
            foreach (var townForDestroy in destroyableTowns)
            {
                if (townForDestroy is IDestroyOnLoad destroy)
                {
                    destroy.DestroyObjectOnLoad();
                }
            }
            
            
            foreach (var town in towns)
            {
                _townFactory = new TownFactory(townsTypes[town.TownType]);
                
                var CreatingTown = _townFactory.CreateTown().gameObject.GetOrAddComponent<CurrentTown>();

                ResourceHeapCreator resourcesAfterDeath = new ResourceHeapCreator(townsTypes[town.TownType].RadiusCollaiderSize);
                 CreatingTown.InitializeTown(_controller, resourcesAfterDeath, townsTypes[town.TownType],
                                town.PlaceOfTown,townsTypes[town.TownType].NameOfTownType ,townsTypes[town.TownType].TimeToDeathAfterDestroy, townsTypes[town.TownType].Health);
            }
        }

    }
}