using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHorizontalMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _horizontalBorder;

    private PlayerInput _input;
    private ISnakeSegments _snakeSegments;

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
        _snakeSegments = GetComponentInParent<ISnakeSegments>();
    }

    private void Update()
    {
        Move();
        BorderCheck(transform.position.x, _horizontalBorder, _horizontalBorder);
        BorderCheck(-_horizontalBorder, transform.position.x, -_horizontalBorder);
    }

    private void Move()
    {
        Vector3 movement = new Vector3(_input.HorizontalMovement * _speed, 0, 0);
        transform.Translate(movement * Time.deltaTime, Space.World);
    }

    private void BorderCheck(float x1, float x2, float border)
    {
        if (x1 > x2)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = border;
            transform.position = newPosition;
        }
    }


}
