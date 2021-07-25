using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Snake : MonoBehaviour, ISnakeSegments, IColor, IColorChanger
{
    [SerializeField] private SnakeHead _head;
    [SerializeField] private SnakeTailEnd _tailEnd;
    [SerializeField] private ColorData _currentColor;

    private List<SnakeSegment> _segments = new List<SnakeSegment>();

    public SnakeHead Head { get => _head; }
    public List<SnakeSegment> Segments { get => _segments; }
    public SnakeTailEnd TailEnd { get => _tailEnd; }
    public ColorData CurrentColor { get => _currentColor;}

    public event Action<ColorData> ColorChanged;

    public void ChangeColor(ColorData color)
    {
        _currentColor = color;
        ColorChanged?.Invoke(color);
    }
}
