using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Eater : MonoBehaviour
{
    [SerializeField] private Transform _fieldOfViewPoint;
    [SerializeField] private Transform _eatPoint;
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private LayerMask _obstacleMask;
    [SerializeField] private float _viewRadius;
    [SerializeField] private float _viewAngle;

    private FieldOfView _fov;

    public Transform EatPoint { get => _eatPoint; }
    public UnityEvent FoodFounded;

    private void Start() 
    {
        _fov = new FieldOfView(_targetMask, _obstacleMask, _viewRadius, _viewAngle);
    }

    private void Update() 
    {
        FindFood();
    }

    private void FindFood()
    {
        List<GameObject> targets = _fov.FindVisibleTargets(_fieldOfViewPoint);

        foreach (var target in targets)
        {
            if(target.TryGetComponent(out Food food))
            {
                if(food.Edible.CheckIsEdible(this))
                {
                    food.StartEat(this);
                    FoodFounded?.Invoke();
                }
            }
        }
    }

    
}
