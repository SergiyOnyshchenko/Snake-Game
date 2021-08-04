using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private LevelData _currentLevelData;
    [Header("Prefabs")]
    [SerializeField] private Road _roadPrefab;
    [SerializeField] private Finish _finishPrefab;
    [Header("Offsets")]
    [SerializeField] private float _roadSpawnOffset = 10f;
    [SerializeField] private Vector2 _segmentSpawnOffset = new Vector2 (3f, 3f);

    private void Start()
    {
        SpawnRoad(_currentLevelData.Segments.Length);
        SpawnSegments(_currentLevelData.Segments);
    }

    private void SpawnRoad(int lenght)
    {
        for (int i = -1; i < lenght + 5; i++)
        {
            Vector3 spawnPosition = CalculateSpawnPosition(i);
            Instantiate(_roadPrefab, spawnPosition, Quaternion.identity, transform);

            if(i == lenght)
                SpawnFinish(spawnPosition);
        }
    }

    private void SpawnSegments(LevelSegment[] segments)
    {
        ColorData previousColor = GetLastColor(segments);
        ColorData currentColor = previousColor;

        for (int i = 0; i < segments.Length; i++)
        {
            if(segments[i] == null) 
                continue;

            Vector3 spawnPosition = CalculateSpawnPosition(i);
            CheckColorSegment(segments[i], ref currentColor, ref previousColor);

            SpawnData data = new SpawnData(transform, _segmentSpawnOffset, currentColor, previousColor);
            _currentLevelData.Segments[i].Spawn(spawnPosition, data);
        }
    }

    private void SpawnFinish(Vector3 spawnPosition)
    {
        FindObjectOfType<CameraController>().SetFinish(spawnPosition.z);
        Instantiate(_finishPrefab, spawnPosition, Quaternion.identity, transform);
    }

    private Vector3 CalculateSpawnPosition(int segmentNumber)
    {
        Vector3 spawnPosition = transform.position;
        spawnPosition.z += segmentNumber * _roadSpawnOffset;
        return spawnPosition;
    }

    private void CheckColorSegment(LevelSegment segment, ref ColorData currentColor, ref ColorData previousColor)
    {
        if (segment is CheckpointSegment)
        {
            if (currentColor != previousColor)
                previousColor = currentColor;

            CheckpointSegment checkpoint = (CheckpointSegment)segment;
            currentColor = checkpoint.Color;
        }
    }   

    private ColorData GetLastColor(LevelSegment[] segments)
    {
        for (int i = segments.Length - 1; i >= 0; i--)
        {
            if (segments[i] is CheckpointSegment)
            {
                CheckpointSegment checkpoint = (CheckpointSegment)segments[i];
                return checkpoint.Color;
            }
        }
        return null;
    }
}
