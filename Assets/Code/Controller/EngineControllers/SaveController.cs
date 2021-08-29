using System;
using System.Collections.Generic;
using Code.Datas;
using Code.Interfaces;
using Code.Savers;
using UnityEngine;

namespace Code.Controller
{
    public class SaveController : ICleanup
    {
        private readonly SnakeContactsController _snakeBase;
        private readonly SaveDataRepository _saveDataRepository;
        
        private IUserInput _saveInput;
        private IUserInput _loadInput;

        public SaveController((IUserInput saveInput, IUserInput loadInput) input, SnakeContactsController snake)
        {
            _snakeBase = snake;

            _saveDataRepository = new SaveDataRepository();

            _saveInput = input.saveInput;
            _loadInput = input.loadInput;

            _saveInput.AxisOnChange += SaveOnChange;
            _loadInput.AxisOnChange += LoadOnChange;
        }

        private void SaveOnChange(float value)
        {
            if (value == 1)
            {
                _saveDataRepository.Save(_snakeBase, new List<TownOnLoadData>());
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