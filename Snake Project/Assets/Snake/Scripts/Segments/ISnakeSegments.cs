using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISnakeSegments
{
    SnakeHead Head { get; }
    List<SnakeSegment> Segments { get; }
    SnakeTailEnd TailEnd { get;}
}
