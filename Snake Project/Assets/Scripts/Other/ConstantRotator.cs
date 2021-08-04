using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotator : MonoBehaviour
{
    [SerializeField] private Vector3 _rotationSpeed;

    private bool _isStopped;

    private void Update() 
    {
        if(_isStopped)
            return;

        transform.Rotate(_rotationSpeed * Time.deltaTime);
    }

    public void Play()
    {
        _isStopped = false;
    }
    
    public void Stop()
    {
        _isStopped = true;
    }
}
