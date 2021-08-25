using System.Collections.Generic;
using UnityEngine;

namespace Code.Interfaces
{
    public interface IResourceHeapCreate
    {
        void CreateResouceHeap(Dictionary<string, float> resources, Vector2 myPlace);
    }
}