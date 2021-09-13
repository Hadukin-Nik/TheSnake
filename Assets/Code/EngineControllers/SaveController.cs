using System;
using System.Collections.Generic;
using Code.Datas;
using Code.Interfaces;
using Code.Savers;
using Code.Towns;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Controller
{
    public class SaveController : ICleanup, IInitialization, ISaver
    {
        public event Action<Transform, List<TownOnLoadData>> Save;
        public event Action<Transform> Load;
        
        private readonly SaveDataRepository _saveDataRepository;
        
        private Transform _snakeBase;

        private ISaver _saver;
        
        private IUserInput _saveInput;
        private IUserInput _loadInput;

        public SaveController(Controllers controller, MainData mainData)
        {
            _saveDataRepository = new SaveDataRepository(controller, this, mainData, mainData.Towns);
        } 

        public void Initialization()
        {
            _saveInput.AxisOnChange += SaveOnChange;
            _loadInput.AxisOnChange += LoadOnChange;        
        }

        public void ButtonInitialization((IUserInput saveInput, IUserInput loadInput) input)
        {
            
            _saveInput = input.saveInput;
            _loadInput = input.loadInput;
        }
        
        private void SaveOnChange(float value)
        {
            if (value == 1)
            {
                CurrentTown[] findObjectsOfType = Object.FindObjectsOfType(typeof(CurrentTown)) as CurrentTown[];
                Debug.Log(findObjectsOfType);
                List<TownOnLoadData> townsOnSave = new List<TownOnLoadData>(findObjectsOfType.Length);
                
                foreach (var townOnSave in findObjectsOfType)
                {
                    TownOnLoadData saveData = new TownOnLoadData(
                        (townOnSave as ISaveable).GetYourType, townOnSave.MyPosition);
                    townsOnSave.Add(saveData);
                }

                _snakeBase = Object.FindObjectOfType<SnakeContactsController>().transform;

                Save(_snakeBase, townsOnSave);
            }
        }
        
        private void LoadOnChange(float value)
        {
            if (value == 1)
            {
                Load.Invoke(_snakeBase);
            }
        }
        
        
        public void Cleanup()
        {
            _saveInput.AxisOnChange -= SaveOnChange;
            _loadInput.AxisOnChange -= LoadOnChange;
        }



    }
}