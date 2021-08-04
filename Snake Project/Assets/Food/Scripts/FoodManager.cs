using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class FoodManager : MonoBehaviour, IFever
{
    public static FoodManager Instance = null;

    private int _colorFoodAmount = 0;
    private int _gemAmount = 0;

    public event Action<int> ColorFoodAded;
    public event Action<int> GemAded;

    private void Awake() 
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void Start() 
    {
        GemAded?.Invoke(_gemAmount);
        ColorFoodAded?.Invoke(_colorFoodAmount);
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

    public void StartFever()
    {
        
    }

    public void EndFever()
    {
        ResetGem();
    }
}
