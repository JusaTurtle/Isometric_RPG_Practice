using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy : Actor
{
    public float range;

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
            return new Vector2(target.transform.position.x - transform.position.x, target.transform.position.z - transform.position.z).normalized;
        }

        return Vector2.zero;
    }

    protected override Vector2 GetRotDir()
    {
        return GetMoveDir();
    }
}
