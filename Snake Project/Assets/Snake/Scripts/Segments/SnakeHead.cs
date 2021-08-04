using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : SnakeSegment
{
    [SerializeField] private float _rotateAngle = 120f;
    [SerializeField] private float _rotateSpeed;

    public bool isActive;

    private PlayerInput _input;
    private float _lastPositionX = 0;

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        HeadRotation();
    }

    private void LateUpdate()
    {
        if (!isActive)
            return;

        PathPosition.Enqueue(transform.position);
    }

    private void HeadRotation() 
    {
        float offset = Mathf.Abs((Mathf.Abs(transform.position.x) - Mathf.Abs(_lastPositionX)));

        if(offset > 0.05f)
        {
            if (transform.position.x > _lastPositionX)
            {
                Rotate(_rotateAngle);
            }
            else if (transform.position.x < _lastPositionX)
            {
                Rotate(-_rotateAngle);
            }
        }
        else
        {
            Rotate(0);
        }

        _lastPositionX = transform.position.x;
    }

    private void Rotate(float angle)
    {
        Vector3 newAngle = Vector3.zero;
        newAngle.y = angle;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(newAngle), Time.deltaTime * _rotateSpeed);
    }
}
