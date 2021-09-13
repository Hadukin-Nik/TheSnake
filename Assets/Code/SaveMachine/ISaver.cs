using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Savers
{
    public interface ISaver
    {
        event Action<Transform, List<TownOnLoadData>> Save;
        event Action<Transform> Load;
    }
}