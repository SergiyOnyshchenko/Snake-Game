using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spawner", menuName = "Spawner/SingleObjectSpawner")]
public class SingleObjectSpawner : LevelObjectSpawner
{
    [SerializeField] private GameObject _prefab;

    public override void Spawn(Vector3 spawnPosition ,SpawnData data)
    {
        Instantiate(_prefab, spawnPosition, Quaternion.identity, data.Parent);
    }
}
