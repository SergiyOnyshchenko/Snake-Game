using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailMover : MonoBehaviour
{
    private ISnakeSegments _snakeSegments;
    private SnakeSpawner _spawner;

    private bool _isTailCreated;

    private void Start()
    {
        _snakeSegments = GetComponent<ISnakeSegments>();
        _spawner = GetComponent<SnakeSpawner>();
    }

    private void Update()
    {
        SegmentsMove();
    }

    private void SegmentsMove()
    {
        SnakeSegment previousSegment = _snakeSegments.Head;

        foreach (SnakeSegment segment in _snakeSegments.Segments)
        {
            Move(segment, previousSegment);
            previousSegment = segment;
        }

        if (!_snakeSegments.TailEnd.IsActive)
            return;

        Move(_snakeSegments.TailEnd, previousSegment);
    }

    private void Move(SnakeSegment currentSegment, SnakeSegment previousSegment)
    {
        Vector3 newPosition = currentSegment.transform.position;
        newPosition.x = previousSegment.Path.Dequeue().x;

        currentSegment.transform.position = newPosition;
        currentSegment.transform.LookAt(previousSegment.transform.position);
    }
}
