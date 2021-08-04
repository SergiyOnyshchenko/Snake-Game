using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Snake : MonoBehaviour, ISnakeSegments, IColor, IColorChanger, IDeath
{
    [SerializeField] private SnakeHead _head;
    [SerializeField] private SnakeTailEnd _tailEnd;
    [SerializeField] private ColorData _currentColor;
    [SerializeField] private ColorData _deathColor;

    private List<SnakeSegment> _segments = new List<SnakeSegment>();

    public SnakeHead Head { get => _head; }
    public List<SnakeSegment> Segments { get => _segments; }
    public SnakeTailEnd TailEnd { get => _tailEnd; }
    public ColorData CurrentColor { get => _currentColor;}

    public event Action<ColorData> ColorChanged;
    public event Action IsDied;

    public void ChangeColor(ColorData color)
    {
        _currentColor = color;
        SetSegmentsColor(color);
    }

    public void SetSegmentsColor(ColorData color)
    {
        ColorChanged?.Invoke(color);
    }

    public void Die()
    {
        IsDied?.Invoke();
        ChangeColor(_deathColor);
        EZCameraShake.CameraShaker.Instance.ShakeHard();
    }
}
