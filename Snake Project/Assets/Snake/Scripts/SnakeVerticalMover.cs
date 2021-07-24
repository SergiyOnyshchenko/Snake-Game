using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeVerticalMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update() 
    {
        Vector3 movement = new Vector3(_speed, 0, 0);
        transform.Translate(movement * Time.deltaTime, Space.World);
    }
}
