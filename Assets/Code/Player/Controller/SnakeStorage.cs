using System.Collections.Generic;

namespace Code.Controller
{
    public class SnakeStorage
    {
        private Dictionary<string, float> _materialsThatWeHaveNow;
        private Dictionary<string, float> _volumeOfResources;
        
        private float _maxVolumeOfResources = 0.0f;
        private float _volumeThatWeHaveNow = 0.0f;
        
        private float _boundariesOfBinSearch = 0.01f;
        
        public SnakeStorage(Dictionary<string, float> volumeOfResources, Dictionary<string, float> materialsThatWeHaveNow, float maxVolumeOfResources)
        {
            _volumeOfResources = volumeOfResources;
            _materialsThatWeHaveNow = materialsThatWeHaveNow;
            foreach (var material in materialsThatWeHaveNow)
            {
                _volumeThatWeHaveNow += _volumeOfResources[material.Key] * material.Value;
            }
            _maxVolumeOfResources = maxVolumeOfResources;
        }
        
        public float TryAddMaterialsToStorage(string nameOfMaterial, float countOfMaterial)
        {
            float added = 0.0f;
            if (_volumeThatWeHaveNow + _volumeOfResources[nameOfMaterial] * countOfMaterial > _maxVolumeOfResources)
            {
                added = BinSearch(countOfMaterial, nameOfMaterial);
            }
            else
            {
                added += _volumeOfResources[nameOfMaterial];
            }

            if (!_materialsThatWeHaveNow.ContainsKey(nameOfMaterial))
            {
                _materialsThatWeHaveNow.Add(nameOfMaterial, added);
            }
            else
            {
                _materialsThatWeHaveNow[nameOfMaterial] += added;
            }
            _volumeThatWeHaveNow += added * _volumeOfResources[nameOfMaterial];
            return countOfMaterial - added;
        }

        private float BinSearch(float maxCountOfResource, string nameOfResource)
        {
            float minCount = 0.0f;
            float maxCount = maxCountOfResource;

            while (maxCount - minCount > _boundariesOfBinSearch)
            {
                float middle = (minCount + maxCount) / 2;
                if (middle * _volumeOfResources[nameOfResource] + _volumeThatWeHaveNow > _maxVolumeOfResources)
                {
                    maxCount = middle;
                }
                else
                {
                    minCount = middle;
                }
            }

            return minCount;
        }
    }
}