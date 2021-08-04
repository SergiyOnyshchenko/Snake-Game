using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineColorSetter : ColorSetter
{
    [SerializeField] private LineRenderer _line;

    private void Start()
    {
        if (_line == null)
            _line = GetComponent<LineRenderer>();

        Init();
    }

    public override void SetColor(ColorData colorData)
    {
        _line.material.color = colorData.Color;
    }
}
