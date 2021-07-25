using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchInput : MonoBehaviour, PlayerInput
{
    private float _horizontalMovement;
    private Vector2 _startPosition;
    private Vector2 _lastPosition;
    private bool _isLeft;

    public float HorizontalMovement { get => _horizontalMovement;}

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startPosition = Input.mousePosition.normalized;
            _lastPosition = _startPosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 currentPosition = Input.mousePosition.normalized;
            
            Swipe(currentPosition.x, _lastPosition.x, false, 1, currentPosition);
            Swipe(_lastPosition.x, currentPosition.x, true, -1, currentPosition);

            _lastPosition = currentPosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _horizontalMovement = 0;
        }
    }

    private void Swipe(float x1, float x2, bool isRight, int direction, Vector2 currentPosition)
    {
        if (x1 > x2)
        {
            ChangeSwipeDirectionCheck(isRight);
            _horizontalMovement = direction * Vector2.Distance(_startPosition, currentPosition);
        }
    }

    private void ChangeSwipeDirectionCheck(bool isRight)
    {
        if (_isLeft == isRight)
            _startPosition = _lastPosition;

        _isLeft = !isRight;
    }
}
