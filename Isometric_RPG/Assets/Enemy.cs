using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    private Transform target;

    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Player")) target = other.transform;
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")) target = null;
    }

    public override void Die()
    {
        Destroy(gameObject);
    }

    public override Vector2 GetInput()
    {
        if (target != null)
            return new Vector2(target.position.x - transform.position.x, target.position.z - transform.position.z).normalized;
        return Vector2.zero;
    }
}
