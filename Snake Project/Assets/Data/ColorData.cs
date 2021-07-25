using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorData", menuName = "Data/ColorData")]
public class ColorData : ScriptableObject
{
    [SerializeField] private Color _color;

    public Color Color { get => _color; }
}
