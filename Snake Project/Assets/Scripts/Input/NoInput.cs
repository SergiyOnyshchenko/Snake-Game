using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoInput : IInput
{
    public event Action<float> Touched;

    private void Start() 
    {
        Touched?.Invoke(0);
    }

    public void GetInputX()
    {
        
    }
}
