using System.IO;
using TMPro;
using UnityEngine;

namespace Code.Datas
{
    [CreateAssetMenu(fileName =  "Data", menuName = "Data/Data")]
    public sealed class MainData : ScriptableObject
    {
        [SerializeField] private string pathToTownsData;
        [SerializeField] private string pathToSnakeData;

        
        [SerializeField] private float _speedOfAppearingTowns;

        [SerializeField] private int _townsOnMapCount;

        private SnakeData _snakeData;
        private TownsData _townsData;

        public SnakeData Snake
        {
            get
            {
                if (_snakeData == null)
                {
                    _snakeData = Load<SnakeData>("Data/" + pathToSnakeData);
                }

                return _snakeData;
            }
        }
        
        public TownsData Towns
        {
            get
            {
                if (_townsData == null)
                {
                    _townsData = Load<TownsData>("Data/" + pathToTownsData);
                }

                return _townsData;
            }
        }
        
        

        private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}