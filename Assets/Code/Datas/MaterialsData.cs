using System.Collections.Generic;

namespace Code.Datas
{
    public class MaterialsData
    {
        private Dictionary<string, float> _volumeOfMaterial;

        public Dictionary<string, float> VolumeOfMaterial
        {
            get
            {
                return _volumeOfMaterial;
            }
        }
    }
}