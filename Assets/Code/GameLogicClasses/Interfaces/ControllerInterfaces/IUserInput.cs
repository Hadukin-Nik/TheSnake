using System;

namespace Code.Interfaces
{
    public interface IUserInput
    {
        event Action<float> AxisOnChange;
        void GetAxis();
    }
}