using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCheckpoint : MonoBehaviour, IColor, IColorChanger
{
    [SerializeField] private ColorData _currentColor;
    [SerializeField] private ColorData _disableColor;
    [SerializeField] private LayerMask _targetLayer;

    private bool _isActive = true;

    public ColorData CurrentColor => _currentColor;

    public event Action<ColorData> ColorChanged;

    public void ChangeColor(ColorData color)
    {
        _currentColor = color;
        ColorChanged?.Invoke(color);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!_isActive)
            return;

        if(other.transform.parent.TryGetComponent(out IColorChanger colorChanger))
        {
            colorChanger.ChangeColor(_currentColor);
            ChangeColor(_disableColor);
            _isActive = false;
        }
    }
}
