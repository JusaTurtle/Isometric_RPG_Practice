using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy : Actor
{
    public float range;
    public Gun weapon;
    public float sqrAttackRange;
    private Transform target;

    private void Update()
    {
        base.Update();
        if (target != null)
        {
            weapon.Attack('b');
        }
    }

    public override void Die()
    {
        Destroy(gameObject);
    }

    public override Vector2 GetMoveDir()
    {
        var targets = Physics.OverlapSphere(transform.position, range);
        foreach (var target in from Collider target in targets
                               where target.CompareTag("Player")
                               select target)
        {
            this.target = target.transform;
            Vector2 deltaPos = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.z - transform.position.z);
            if (deltaPos.sqrMagnitude >= sqrAttackRange)
            {
                return deltaPos.normalized;
            }
            else
            {
                this.target = target.transform;
                return Vector2.zero;
            }
        }
        target = null;
        return Vector2.zero;
    }

    protected override Vector2 GetRotDir()
    {
        return GetMoveDir();
    }
}
