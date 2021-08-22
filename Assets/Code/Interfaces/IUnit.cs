using UnityEngine;

namespace Code.Interfaces
{
    public interface IUnit
    {
        float LengthStep { get; }
        float CountOfStepsInSecond { get; }
    }
}