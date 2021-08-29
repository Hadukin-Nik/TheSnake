using System.Collections.Generic;
using Code.Interfaces;
using UnityEngine;

namespace Code.Towns
{
    public class ResourceHeapAfterDeath: MonoBehaviour, IMaterialHeap
    {
        public Dictionary<string, float> resources { get; set; }
        
    }
}