using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelSegment : ScriptableObject
{
    public abstract void Spawn(Vector3 spawnPosition, SpawnData data);
}