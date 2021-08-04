using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class FoodManager : IFever
{
    private int _colorFoodAmount = 0;
    private int _gemAmount = 0;
    private static FoodManager _instance = null;

    public event Action<int> ColorFoodAded;
    public event Action<int> GemAded;

    public static FoodManager Instance{
        get{
            if (_instance == null)
                _instance = new FoodManager();
            return _instance;
        }
    }

    public void AddColorFood()
    {
        _colorFoodAmount += 1;
        ColorFoodAded?.Invoke(_colorFoodAmount);
    }

    public void AddGem()
    {
        _gemAmount += 1;
        GemAded?.Invoke(_gemAmount);
    }

    public void ResetGem()
    {
        _gemAmount = 0;
        GemAded?.Invoke(_gemAmount);
    }

    public void StartFever(){}

    public void EndFever()
    {
        ResetGem();
    }
}
