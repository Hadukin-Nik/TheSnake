using System.IO;
using UnityEngine;
using UnityEngine.Serialization;
using Object = System.Object;

namespace Code.Datas
{
    [CreateAssetMenu(fileName =  "MainData", menuName = "Data/Data")]
    public sealed class MainData : ScriptableObject
    {
        [SerializeField] private string pathToTownsData;
        [SerializeField] private string pathToSnakeData;

        [SerializeField] private Vector2 _sizeOfLevel;
        [SerializeField] private Vector2 _sizeOfCell;
        
        [SerializeField] private float _speedOfTownsAppearing;
        
        [SerializeField] private int _townsOnMapCount;
        
        private SnakeData _snakeData;
        private TownsData _townsData;

        public SnakeData Snake
        {
            get
            {
                if (_snakeData == null)
                {
                    Debug.Log("!!!");
                    _snakeData = Resources.Load<SnakeData>("Data/" + pathToSnakeData);  
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
                    _townsData = Resources.Load<TownsData>(Path.ChangeExtension("Data/" + pathToTownsData, null));  
                }

                return _townsData;
            }
        }
        
        

        private T Load<T>(string resourcesPath) where T : UnityEngine.Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
        
        public Vector2 SizeOfLevel
        {
            get
            {
                return _sizeOfLevel;
            }
        }
        public Vector2 SizeOfCell
        {
            get
            {
                return _sizeOfCell;
            }
        }

        public float SpeedOfTownsAppearing
        {
            get
            {
                return _speedOfTownsAppearing;
            }
        }

        public float MaxCountOfTownsOnLevel
        {
            get
            {
                return _townsOnMapCount;
            }
        }
    }
}