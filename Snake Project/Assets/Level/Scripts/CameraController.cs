using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _followObject;
    [SerializeField] private float _offsetZ;
    [SerializeField] private float _startZ;

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

        if(_startZ > _followObject.position.z + _offsetZ)
            return;

        Vector3 newPosition = transform.position;
        newPosition.z = _followObject.position.z + _offsetZ;
        transform.position = newPosition;
    }
}

