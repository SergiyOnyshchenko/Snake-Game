using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Segment", menuName = "Data/ContentSegment")]
public class ContentSegment : LevelSegment
{
    [SerializeField] private Vector2 _spawnPositionMultiplier = Vector2.one;
    [SerializeField] private LevelSegmentColumn[] _row = new LevelSegmentColumn[3];

    public override void Spawn(Vector3 spawnPosition, SpawnData data)
    {
        float offsetY = CalculateOffset(_row.Length);

        for (int i = 0; i < _row.Length; i++)
        {
            LevelObjectSpawner[] currentColumn = _row[i].Column;
            float offsetX = CalculateOffset(currentColumn.Length);

            for (int j = 0; j < currentColumn.Length; j++)
            {
                if (currentColumn[j] == null)
                    continue;

                Vector3 newSpawnPosition = Vector3.zero;
                newSpawnPosition += new Vector3(j - offsetX, 0, i - offsetY);
                newSpawnPosition.x *= data.SegmentSpawnOffset.x * _spawnPositionMultiplier.x;
                newSpawnPosition.z *= data.SegmentSpawnOffset.y * _spawnPositionMultiplier.y;
                newSpawnPosition += spawnPosition;

                currentColumn[j].Spawn(newSpawnPosition, data);
            }
        }
    }

    private float CalculateOffset(int length)
    {
        float offset = 0;
        for (int i = 0; i < length; i++)
        {
            offset += i;
        }
        return offset / length;
    }
}
