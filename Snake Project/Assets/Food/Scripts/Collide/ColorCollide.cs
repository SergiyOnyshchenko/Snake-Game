using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCollide : KillCollide
{
    private ColorData _currentColor;

    public ColorCollide(ColorData currentColor)
    {
        _currentColor = currentColor;
    }

    public override void CollideWithOpponent(GameObject target)
    {
        if (target.TryGetComponent(out IColor color))
        {
            if (color.CurrentColor != _currentColor)
                Kill(target);
        }
    }
}
