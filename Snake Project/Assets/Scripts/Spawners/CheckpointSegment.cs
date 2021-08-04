using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CheckpointSegment", menuName = "Data/CheckpointSegment")]
public class CheckpointSegment : LevelSegment
{
    [SerializeField] private ColorCheckpoint _prefab;
    [SerializeField] private ColorData _color;

    public ColorData Color { get => _color;}

    public override void Spawn(Vector3 spawnPosition, SpawnData data)
    {
        ColorCheckpoint newCheckpoint = Instantiate(_prefab, spawnPosition, Quaternion.identity, data.Parent);
        IColorChanger colorChanger = newCheckpoint.GetComponent<IColorChanger>();
        colorChanger.ChangeColor(_color);
    }
}
