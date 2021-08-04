using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IFever
{
    private IInput _currentInput;
    private IDeath _death;

    public event Action<float> Touched;

    private void Start() 
    {
        _death = GetComponentInParent<IDeath>();
        _death.IsDied += SetNoInput;

        GameManager.Instance.LevelFinished += SetNoInput;

        SetInput(new PlayerTouchInput());
    }

    private void OnDestroy() 
    {
        _death.IsDied -= SetNoInput;
        GameManager.Instance.LevelFinished -= SetNoInput;
    }
    
    private void Update() 
    {
        _currentInput.GetInputX();
    }

    private void SetInput(IInput newInput)
    {
        if (_currentInput != null)
            _currentInput.Touched -= Touch;

        _currentInput = newInput;
        _currentInput.Touched += Touch;
    }

    private void Touch(float x)
    {
        Touched?.Invoke(x);
    }

    public void StartFever()
    {
        SetInput(new FeverInput());
    }

    public void EndFever()
    {
        SetInput(new PlayerTouchInput());
    }

    private void SetNoInput()
    {
        SetInput(new NoInput());
    }
}
