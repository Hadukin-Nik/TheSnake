using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Controller
{
    public class GameMapInitialization
    {
        private Dictionary<string, int> _countOfCreatedTypesOfTowns;
        
        private List<List<bool>> _usedCells;


        private Vector2 _mapSize;
        private Vector2 _cellSize;
        
        
        public GameMapInitialization(Vector2 mapSize, Vector2 cellSize)
        {
            _mapSize = mapSize;
            _cellSize = cellSize;

            _usedCells = createMapOfTypeT<bool>(false);
        }

        
        
        public  List<List<T>> createMapOfTypeT<T>(T firstValue) where  T: struct
        {
            int townsCountByX = (int)Math.Floor(_mapSize.x / _cellSize.x) - 1, townsCountByY = (int)Math.Floor(_mapSize.y / _cellSize.y) - 1;
            var map = new List<List<T>>(townsCountByY);
            for (var i = 0; i < townsCountByY; i++)
            {
                map.Add(new List<T>(townsCountByX));
                for (var j = 0; j < townsCountByX; j++) map[i].Add(firstValue);
            }
            return map;
        }
        
    }
    
}