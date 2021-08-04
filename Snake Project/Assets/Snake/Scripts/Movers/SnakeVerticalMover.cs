using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeVerticalMover : MonoBehaviour, IFever
{
    [SerializeField] private float _speed;

    private float _speedMultiplier = 1;
    private IDeath _death;

    private void Start() 
    {
        _death = GetComponent<Snake>();
        _death.IsDied += Stop;
    }

    private void OnDestroy() 
    {
        _death.IsDied -= Stop;
    }

    private void Update() 
    {
        Move();
    }

    private void Move()
    {
        Vector3 movement = new Vector3(0, 0, _speed) * _speedMultiplier;
        transform.Translate(movement * Time.deltaTime, Space.World);
    }

    private void Stop()
    {
        _speedMultiplier = 0;
    }

    public void StartFever()
    {
        _speedMultiplier = 3;
    }

    public void EndFever()
    {
        _speedMultiplier = 1;
    }
}
