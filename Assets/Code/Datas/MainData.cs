using System.IO;
using UnityEngine;
using Object = System.Object;

namespace Code.Datas
{
    [CreateAssetMenu(fileName =  "MainData", menuName = "Data/Data")]
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
    }
}