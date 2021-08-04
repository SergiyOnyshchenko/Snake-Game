using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : SnakeSegment
{
    private void LateUpdate()
    {
        PathPosition.Enqueue(transform.position);
    }
}
