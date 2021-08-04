using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorEdible : IEdible
{
    private ColorData _currentColor;

    public ColorEdible(ColorData currentColor)
    {
        _currentColor = currentColor;
    }

    public bool CheckIsEdible(Eater eater)
    {
        if (eater.TryGetComponent(out IColor color))
        {
            if (color.CurrentColor == _currentColor)
                return true;
            else
                return false;
        }
        else
        {
            return false;
        }
    }
}
