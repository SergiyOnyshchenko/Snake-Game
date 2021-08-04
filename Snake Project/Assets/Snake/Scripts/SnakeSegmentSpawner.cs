using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSegmentSpawner : MonoBehaviour
{
    [SerializeField] private SnakeSegment _segmentPrefab;
    [SerializeField] private SnakeSegment _segmentHollowPrefab;
    [SerializeField] private int _startSegmentsCount;
    [SerializeField] private int _activeSegmentsCount;
    [SerializeField] private float _offsetBetweenSegments;
    [SerializeField] private float _spawnDelay;

    private ISnakeSegments _snakeSegments;

    private void Start() 
    {
        _snakeSegments = GetComponent<ISnakeSegments>();
        StartCoroutine(CreateStartSegments(_spawnDelay));
    }

    public void CreateSegment()
    {
        _snakeSegments.TailEnd.IsActive = false;

        SnakeSegment previousSegment = GetPrevoiusSegment();
        SnakeSegment currentSegment;

        if (_activeSegmentsCount > 0)
            currentSegment = Spawn(_segmentPrefab, previousSegment, _offsetBetweenSegments);
        else
            currentSegment = Spawn(_segmentHollowPrefab, previousSegment, _offsetBetweenSegments);

        _snakeSegments.Segments.Add(currentSegment);
        SetTailEnd(currentSegment, _snakeSegments.TailEnd, _offsetBetweenSegments, _spawnDelay);
        _activeSegmentsCount--;
    }

    private IEnumerator CreateStartSegments(float delay)
    {
        yield return new WaitForSeconds(delay);
        _snakeSegments.Head.isActive = true;

        for (int i = 0; i < _startSegmentsCount; i++)
        {
            yield return new WaitForSeconds(delay);
            CreateSegment();
        }
    }

    private SnakeSegment GetPrevoiusSegment()
    {
        if (_snakeSegments.Segments.Count > 0)
            return _snakeSegments.Segments[_snakeSegments.Segments.Count - 1];
        else
            return _snakeSegments.Head;
    }

    private SnakeSegment Spawn(SnakeSegment prefab, SnakeSegment previousSegment, float offset)
    {
        return Instantiate(
            prefab,
            previousSegment.transform.position + new Vector3(0, 0, offset),
            previousSegment.transform.rotation,
            transform);
    }

    private void SetTailEnd(SnakeSegment currentSegment, SnakeTailEnd tailEndSegment, float offset, float delay)
    {
        SetPosition(currentSegment, tailEndSegment, offset);
        SetRotation(currentSegment, tailEndSegment);
        StartCoroutine(SetActiveTailEnding(tailEndSegment, delay));
    }

    private void SetPosition(SnakeSegment previousSegment, SnakeSegment currentSegment, float offset)
    {
        Vector3 position = previousSegment.transform.position + new Vector3(0, 0, offset);
        currentSegment.transform.position = position;
    }

    private void SetRotation(SnakeSegment previousSegment, SnakeSegment currentSegment)
    {
        previousSegment.transform.LookAt(currentSegment.transform);
    }

    private IEnumerator SetActiveTailEnding(SnakeTailEnd segment, float delay)
    {
        yield return new WaitForSeconds(delay);
        segment.IsActive = true;
    }
}
