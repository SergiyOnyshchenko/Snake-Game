using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHorizontalMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _borderMultiplier;

    private PlayerInput _input;

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
        _input.Touched += Move;
    }

    private void OnDisable()
    {
        _input.Touched -= Move;
    }

    private void Move(float touchPosition)
    {
        Vector3 targetPosition = transform.position;
        targetPosition.x = touchPosition * _borderMultiplier;

        float step = _speed * Time.deltaTime * Vector3.Distance(transform.position, targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }

}
