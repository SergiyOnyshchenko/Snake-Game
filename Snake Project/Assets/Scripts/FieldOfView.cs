using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private LayerMask _obstacleMask;
    [SerializeField] private Transform _eaterPoint;

    private List<Food> visibleTargets = new List<Food>();

    public float ViewRadius;
    [Range(0, 360)] public float ViewAngle;
    public UnityEvent FoodFounded;

    private void Update() 
    {
        FindVisibleTargets();
    }

    public void FindVisibleTargets()
    {
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, ViewRadius, _targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) > ViewAngle / 2)
                continue;

            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if (Physics.Raycast(transform.position, directionToTarget, distanceToTarget, _obstacleMask))
                continue;

            if (target.TryGetComponent(out Food food))
            {
                visibleTargets.Add(food);
                food.Eat(_eaterPoint);
            }
        }

        if (visibleTargets.Count == 0)
            return;

        FoodFounded?.Invoke();
    }



    ViewCastInfo ViewCast(float globalAngle)
    {
        Vector3 dir = DirFromAngle(globalAngle, true);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, dir, out hit, ViewRadius, _obstacleMask))
        {
            return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
        }
        else
        {
            return new ViewCastInfo(false, transform.position + dir * ViewRadius, ViewRadius, globalAngle);
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    public struct ViewCastInfo
    {
        public bool hit;
        public Vector3 point;
        public float dst;
        public float angle;

        public ViewCastInfo(bool _hit, Vector3 _point, float _dst, float _angle)
        {
            hit = _hit;
            point = _point;
            dst = _dst;
            angle = _angle;
        }
    }

    public struct EdgeInfo
    {
        public Vector3 pointA;
        public Vector3 pointB;

        public EdgeInfo(Vector3 _pointA, Vector3 _pointB)
        {
            pointA = _pointA;
            pointB = _pointB;
        }
    }
}
