using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchInput : IInput
{
    public event Action<float> Touched;

    public void GetInputX()
    {
        if (Input.GetMouseButton(0))
        {
            float mouseRatioX = Input.mousePosition.x / Screen.width;
            Touched?.Invoke(mouseRatioX - 0.5f);
        }
    }
}
