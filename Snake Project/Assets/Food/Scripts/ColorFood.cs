using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFood : Food, IColor, IColorChanger, IFever
{
    [SerializeField] private ColorData _currentColor;

    private ICollide _snakeCollide;

    public ColorData CurrentColor => _currentColor;
    public event Action<ColorData> ColorChanged;

    private void Start() 
    {
        Init();
    }

    public void ChangeColor(ColorData color)
    {
        _currentColor = color;
        ColorChanged?.Invoke(color);
    }

    public void StartFever()
    {
        Edible = new AlwaysEdible();
        _snakeCollide = new NonCollide();
    }

    public void EndFever()
    {
        Init();
    }

    protected override void FinishEat()
    {
        FoodManager.Instance.AddColorFood();
    }

    private void Init()
    {
        ChangeColor(_currentColor);
        Edible = new ColorEdible(_currentColor);
        _snakeCollide = new ColorCollide(_currentColor);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.transform.parent == null)
            return;

        if (other.transform.parent.TryGetComponent(out Snake snake))
        {
            _snakeCollide.CollideWithOpponent(snake.gameObject);
        }
    }


}
