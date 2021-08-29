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
    public class SaveController : ICleanup
    {
        private readonly Transform _snakeBase;
        private readonly SaveDataRepository _saveDataRepository;
        
        private IUserInput _saveInput;
        private IUserInput _loadInput;

        public SaveController(Controllers controller, TownsData townsData, (IUserInput saveInput, IUserInput loadInput) input, Transform snake)
        {
            _snakeBase = snake;

            _saveDataRepository = new SaveDataRepository(controller, townsData);

            _saveInput = input.saveInput;
            _loadInput = input.loadInput;

            _saveInput.AxisOnChange += SaveOnChange;
            _loadInput.AxisOnChange += LoadOnChange;
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
                        (townOnSave as ISaveable).GetYourType, (townOnSave as ISaveable).MyGameObject.transform.position);
                    townsOnSave.Add(saveData);
                }
                
                _saveDataRepository.Save(_snakeBase, townsOnSave);
            }
        }
        
        private void LoadOnChange(float value)
        {
            if (value == 1)
            {
                _saveDataRepository.Load(_snakeBase);
            }
        }
        
        public void Cleanup()
        {
            _saveInput.AxisOnChange -= SaveOnChange;
            _loadInput.AxisOnChange -= LoadOnChange;
        }
    }
}