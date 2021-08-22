using System;

namespace Code.Interfaces
{
    public interface IUserInput
    {
        event Action<float> axisOnChange;
        void GetAxis();
    }
}