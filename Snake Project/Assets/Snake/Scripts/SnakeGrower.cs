using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGrower : MonoBehaviour
{
    [SerializeField] private int _eatFoodBeforeAddSegment;

    private int _eatFoodCount;
    private SnakeSegmentSpawner _spawner;

    private void Awake() 
    {
        _spawner = GetComponent<SnakeSegmentSpawner>();
        _eatFoodCount = _eatFoodBeforeAddSegment;
    }

    private void OnEnable()
    {
        FoodManager.Instance.ColorFoodAded += CheckAddNewSegment;
    }

    private void OnDisable()
    {
        FoodManager.Instance.ColorFoodAded -= CheckAddNewSegment;
    }

    private void CheckAddNewSegment(int count)
    {
        _eatFoodCount--;
        if (_eatFoodCount <= 0)
        {
            _spawner.CreateSegment();
            _eatFoodCount = _eatFoodBeforeAddSegment;
        }
    }
}
