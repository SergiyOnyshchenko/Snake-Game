using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAnimation : MonoBehaviour, IFever
{
    [SerializeField] private ColorData _whiteColor;
    [SerializeField] private float _delay = 0.1f;

    private IColor _color;
    private Snake _snake;
    private bool _isActive;

    private void Start() 
    {
        _color = GetComponent<IColor>();
        _snake = GetComponent<Snake>();
    }
    
    public void StartFever()
    {
        _isActive = true;
        StartCoroutine(ColorChangeAnimation());
    }

    public void EndFever()
    {
        _isActive = false;   
    }

    private IEnumerator ColorChangeAnimation()
    {
        bool isWhite = false;

        while (_isActive)
        {
            yield return new WaitForSeconds(_delay);

            if (isWhite)
                _snake.SetSegmentsColor(_whiteColor);

            else
                _snake.SetSegmentsColor(_color.CurrentColor);

            isWhite = !isWhite;
        }

        _snake.ChangeColor(_color.CurrentColor);
    }
}
