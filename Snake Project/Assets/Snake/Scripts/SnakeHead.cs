using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : SnakeSegment
{
    [Range(0, 90)] [SerializeField] private float _rotateAngle;
    [SerializeField] private float _rotateSpeed;

    public bool isActive;

    private PlayerInput _input;
    private HingeJoint _joint;
    private Vector3 _currentAngle = Vector3.zero;

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
        _joint = GetComponentInChildren<HingeJoint>();
    }

    private void Update() 
    {
        Vector3 newAngle = new Vector3(0, _input.HorizontalMovement * _rotateAngle, 0);
        _currentAngle = Vector3.Lerp(_currentAngle, newAngle, Time.deltaTime * _rotateSpeed);

        transform.eulerAngles = _currentAngle;
    }

    private void LateUpdate()
    {
        if (!isActive)
            return;

        Path.Enqueue(transform.position);
    }
}
