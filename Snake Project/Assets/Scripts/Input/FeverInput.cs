using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverInput : IInput
{
    public event Action<float> Touched;
    
    public void GetInputX()
    {
        Touched?.Invoke(0);
    }
}
