using System;

public interface IColor
{
    ColorData CurrentColor { get; }

    event Action<ColorData> ColorChanged;
}
