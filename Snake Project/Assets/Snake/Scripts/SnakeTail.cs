using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : SnakeSegment
{
    private void LateUpdate()
    {
        Path.Enqueue(transform.position);
    }
}
