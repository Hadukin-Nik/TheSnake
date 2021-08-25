using System.Collections.Generic;

namespace Code.Interfaces
{
    public interface IMaterialHeap
    {
        public Dictionary<string, float> resources { get; set; }
    }
}