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
        [SerializeField] private string pathToSectionsData;
        [SerializeField] private string pathToButtonsData;

        [SerializeField] private Vector2 _sizeOfLevel;
        [SerializeField] private Vector2 _sizeOfCell;
        
        [SerializeField] private float _speedOfTownsAppearing;
        
        [SerializeField] private int _townsOnMapCount;
        
        private SnakeData _snakeData;
        private SectionsData _sectionsData;
        private TownsData _townsData;
        private ButtonsData _buttonsData;

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

        public SectionsData Sections
        {
            get
            {
                if (_sectionsData == null)
                {
                    _sectionsData = Load<SectionsData>("Data/" + pathToSectionsData);
                }

                return _sectionsData;
            }
        }
        
        public ButtonsData Buttons
        {
            get
            {
                if (_buttonsData == null)
                {
                    _buttonsData = Load<ButtonsData>("Data/" + pathToButtonsData);
                }

                return _buttonsData;
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

        public int MaxCountOfTownsOnLevel
        {
            get
            {
                return _townsOnMapCount;
            }
        }
    }
}