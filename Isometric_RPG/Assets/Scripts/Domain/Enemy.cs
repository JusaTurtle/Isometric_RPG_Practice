using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy : Actor
{
    public Gun weapon;
    public float sqrAttackRange;
    private Transform target;

    public override void Die()
    {
        Debug.Log("DEAD");
    }

    public override Vector2 GetMoveDir()
    {
        if(target != null)
        {
            Vector2 deltaPos = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.z - transform.position.z);
            if (deltaPos.sqrMagnitude >= sqrAttackRange)
            {
                return deltaPos.normalized;
            }
            else
            {
                this.target = target.transform;
                weapon.Attack('b');
                return Vector2.zero;
            }
        }
        return Vector2.zero;
    }

    protected override Vector2 GetRotDir()
    {
        return GetMoveDir();
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
