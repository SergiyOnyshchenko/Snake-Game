using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _followObject;
    [SerializeField] private float _offsetX;

    private bool _isStop;

    public bool IsStop { get => _isStop; set => _isStop = value; }

    private void Start() 
    {
        if(_followObject == null)
            _followObject = FindObjectOfType<Snake>().transform;
    }

    private void Update() 
    {
        if(_followObject == null)
            return;

        if(_isStop)
            return;

        Vector3 newPosition = transform.position;
        newPosition.x = _followObject.position.x + _offsetX;
        transform.position = newPosition;
    }
}

