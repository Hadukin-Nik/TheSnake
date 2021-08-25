using System.Collections.Generic;
using Code.Datas;
using Code.Interfaces;
using Code.Towns;
using Code.UnityExtentions;
using UnityEngine;

namespace Code.Controller
{
    public class ResourceHeapCreator : IResourceHeapCreate
    {
        private float _radiusSize;
        public ResourceHeapCreator(float radiusSize)
        {
            _radiusSize = radiusSize;
        }

        public void CreateResouceHeap(Dictionary<string, float> resources, Vector2 myPlace)
        {
            GameObject resourceHeap = new GameObject().AddCircleCollider2D(_radiusSize);
            resourceHeap.GetOrAddComponent<ResourceHeapAfterDeath>().resources = resources;
            resourceHeap.transform.position = myPlace;
        }
    }


}