using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CameraShaker _cameraShaker;
    [SerializeField] private Transform _followObject;
    [SerializeField] private float _offsetZ;
    [SerializeField] private float _startZ;

    private float _finishZ;
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

        if (_finishZ < _followObject.position.z + _offsetZ)
            return;

        Vector3 newPosition = _cameraShaker.RestPositionOffset;
        newPosition.z = _followObject.position.z + _offsetZ;
        _cameraShaker.RestPositionOffset = newPosition;
    }

    public void SetFinish(float z)
    {
        _finishZ = z;
    }
}

