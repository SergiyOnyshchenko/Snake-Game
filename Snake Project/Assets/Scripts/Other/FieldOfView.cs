using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FieldOfView
{
    private LayerMask _targetMask;
    private LayerMask _obstacleMask;
    private float _viewRadius;
    private float _viewAngle;

    public FieldOfView(LayerMask targetMask, LayerMask obstacleMask, float viewRadius, float viewAngle)
    {
        _targetMask = targetMask;
        _obstacleMask = obstacleMask;
        _viewRadius = viewRadius;
        _viewAngle = viewAngle;
    }

    public List<GameObject> FindVisibleTargets(Transform transform)
    {
        List<GameObject> visibleTargets = new List<GameObject>();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, _viewRadius, _targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) > _viewAngle / 2)
                continue;

            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if (Physics.Raycast(transform.position, directionToTarget, distanceToTarget, _obstacleMask))
                continue;

            visibleTargets.Add(target.gameObject);
        }

        return visibleTargets;
    }
}
