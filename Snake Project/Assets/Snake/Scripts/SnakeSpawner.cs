using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSpawner : MonoBehaviour
{
    [SerializeField] private SnakeSegment _segmentPrefab;
    
    [SerializeField] private int _startSegmentsCount;
    [SerializeField] private float _offsetBetweenSegments;
    [SerializeField] private float _spawnDelay;

    private ISnakeSegments _snakeSegments;

    public Action<SnakeSegment> SegmentAded;

    private void Start() 
    {
        _snakeSegments = GetComponent<ISnakeSegments>();

        StartCoroutine(CreateStartSegments());
    }

    private void LateUpdate() 
    {
        if (Input.GetKeyDown("w"))
        {
            AddSegment();
        }
    }

    private IEnumerator CreateStartSegments()
    {
        yield return new WaitForSeconds(_spawnDelay);
        _snakeSegments.Head.isActive = true;

        for (int i = 0; i < _startSegmentsCount; i++)
        {
            yield return new WaitForSeconds(_spawnDelay);

            if(i == 0)
                yield return new WaitForSeconds(_spawnDelay);

            AddSegment();
        }
    }

    private void AddSegment()
    {
        _snakeSegments.TailEnd.IsActive = false;

        _snakeSegments.Segments.Add(Instantiate(_segmentPrefab, transform));
        SetSegmentsPositions();

        StartCoroutine(SetTailEnd());
    }

    private IEnumerator SetTailEnd()
    {
        yield return new WaitForSeconds(_spawnDelay);
        _snakeSegments.TailEnd.IsActive = true;
    }

    private void SetSegmentsPositions()
    {
        SnakeSegment previousSegment = _snakeSegments.Head;

        foreach (SnakeSegment segment in _snakeSegments.Segments)
        {
            SetPosition(previousSegment, segment);
            previousSegment = segment;
        }

        SetPosition(previousSegment, _snakeSegments.TailEnd);
    }

    private void SetPosition(SnakeSegment previousSegment, SnakeSegment currentSegment)
    {
        Vector3 position = previousSegment.transform.position + new Vector3(0, 0, _offsetBetweenSegments);
        currentSegment.transform.position = position;
    }


}
