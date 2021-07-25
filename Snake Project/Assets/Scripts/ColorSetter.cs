using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ColorSetter : MonoBehaviour
{
    private IColor _color;

    public void Init()
    {
        _color = GetComponentInParent<IColor>();
        _color.ColorChanged += SetColor;
        SetColor(_color.CurrentColor);
    }

    public abstract void SetColor(ColorData colorData);
}
