using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : SnakeSegment
{
    public bool IsLast;

    private void LateUpdate()
    {
        if(IsLast)
            return;

        Path.Enqueue(transform.position);
    }
}
