using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelSegmentColumn
{ 
    [SerializeField] private LevelObjectSpawner[] _column = new LevelObjectSpawner[3];

    public LevelObjectSpawner[] Column { get => _column;}
}
