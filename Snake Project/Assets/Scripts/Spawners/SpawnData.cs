using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SpawnData
{
    public Transform Parent { get; private set; }
    public Vector2 SegmentSpawnOffset { get; private set; }
    public ColorData EdibleColor { get; private set; }
    public ColorData NonEdibleColor { get; private set; }

    public SpawnData(Transform parent, Vector2 segmentSpawnOffset, ColorData edibleColor, ColorData nonEdibleColor)
    {
        Parent = parent;
        SegmentSpawnOffset = segmentSpawnOffset;
        EdibleColor = edibleColor;
        NonEdibleColor = nonEdibleColor;
    }
}
