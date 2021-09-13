using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor.U2D.Path;
using UnityEngine;

namespace Code.Datas
{
    [CreateAssetMenu(fileName =  "SectionsData", menuName = "Data/Builder/SectionsData")]

    public class SectionsData : ScriptableObject
    {
        [SerializeField] private List<SectionData> _sections;

        public List<SectionData> Sections
        {
            get
            {
                return _sections;
            }
        } 
    }

    [Serializable]
    public class SectionData
    {
        public int ButtonCallType;
        public string Name;
        public string DataPlace;

        private SectionTypeData _sectionTypeData;

        public SectionTypeData SectionTypeData
        {
            get
            {
                if (_sectionTypeData == null)
                {
                    _sectionTypeData = Load<SectionTypeData>("Data/" + DataPlace);
                }

                return _sectionTypeData;
            }
        }
            
        private T Load<T>(string resourcesPath) where T : UnityEngine.Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
    
    public class SectionTypeData : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private string _name;
        
        [SerializeField] private float _radius;
        public Sprite Sprite
        {
            get
            {
                return _sprite;
            }
        }
        
        public string Name
        {
            get
            {
                return _name;
            }
        }
        
        public float Radius
        {
            get
            {
                return _radius;
            }
        }
        
    }
    [CreateAssetMenu(fileName =  "ContainerCell", menuName = "Data/Builder/ContainerCell")]

    public class SectionContainerData : SectionTypeData
    {
        [SerializeField] private float _addedValumeOfStorage;

        public float AddedValumeOfStorage
        {
            get
            {
                return _addedValumeOfStorage;
            }
        }
    }
}