
using System;

public interface IInput
{
    event Action<float> Touched;

    void GetInputX();
}
