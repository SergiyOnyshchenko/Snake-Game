using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Data/LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField] private LevelSegment[] _segments;

    public LevelSegment[] Segments { get => _segments;}
}
