using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHorizontalMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _horizontalBorder;
    [SerializeField] private float _delayTime = 0.5f;

    private PlayerInput _input;
    private Snake _snake;

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
        _snake = GetComponentInParent<Snake>();
    }

    private void Update()
    {
        Move();
        BorderCheck(transform.position.z, _horizontalBorder, _horizontalBorder);
        BorderCheck(-_horizontalBorder, transform.position.z, -_horizontalBorder);
        BodyPartsMove();
    }

    private void Move()
    {
        Vector3 movement = new Vector3(0, 0, _input.HorizontalMovement * _speed);
        transform.Translate(movement * Time.deltaTime, Space.World);
    }

    private void BorderCheck(float z1, float z2, float border)
    {
        if (z1 > z2)
        {
            Vector3 newPosition = transform.position;
            newPosition.z = border;
            transform.position = newPosition;
        }
    }


    private void BodyPartsMove()
    {
        for (int i = 1; i < _snake.Segments.Count; i++)
        {
            SnakeSegment currentBodyPart = _snake.Segments[i];
            SnakeSegment previuusBodyPart = _snake.Segments[i - 1];

            Vector3 newPosition = currentBodyPart.transform.position;
            newPosition.z = previuusBodyPart.Path.Dequeue().z;

            currentBodyPart.transform.position = newPosition;
            currentBodyPart.transform.rotation = Quaternion.LookRotation(previuusBodyPart.transform.position - currentBodyPart.transform.position);
        }
    }
}
