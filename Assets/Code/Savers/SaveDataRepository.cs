using System.Collections.Generic;
using System.IO;
using Code.Controller;
using UnityEngine;

namespace Code.Savers
{
    public class SaveDataRepository
    {
        private readonly IData<SavedData> _data;

        private const string _folderName = "dataSave";
        private string _fileName = "data.bat";
        private readonly string _path;

        public SaveDataRepository()
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
        }


        public void Save(SnakeContactsController snake, List<TownOnLoadData> towns)
        {
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

        public void Load(SnakeContactsController snake)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file)) return;
            var newPlayer = _data.Load(file);
            snake.transform.position = (Vector2)newPlayer.PlayerPosition;
            snake.name = newPlayer.Name;
        }

    }
}