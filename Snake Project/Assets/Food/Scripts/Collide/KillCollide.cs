using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCollide : ICollide
{
    public virtual void CollideWithOpponent(GameObject target)
    {
        Kill(target);
    }

    protected void Kill(GameObject target)
    {
        if (target.TryGetComponent(out IDeath death))
        {
            death.Die();
        }
    }
}
