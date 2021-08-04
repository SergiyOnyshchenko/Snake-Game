using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MultipleObjectSpawner : LevelObjectSpawner
{
    [SerializeField] private int _count;
    [SerializeField] private float _minRadius;
    [SerializeField] private float _maxRadius;
    
    public override void Spawn(Vector3 spawnPosition, SpawnData data)
    {
        for (int i = 0; i < _count; i++)
        {
            float currentRadius = Random.Range(_minRadius, _maxRadius);
            float angle = i * Mathf.PI * 2f / _count;

            Vector3 newSpawnPosition = Vector3.zero;
            newSpawnPosition.x = currentRadius * Mathf.Cos(angle);
            newSpawnPosition.z = currentRadius * Mathf.Sin(angle);
            newSpawnPosition += spawnPosition;

            SpawnOneObject(newSpawnPosition, data);
        }
    }

    public abstract void SpawnOneObject(Vector3 position, SpawnData data);
}
