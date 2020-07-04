using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int dame;
    public LayerMask whatCanBeHit;
    private Player owner;

    private void Start()
    {
        DetectHit();
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
        DetectHit();
    }

    private void DetectHit()
    {
        if (IsNextFrameHit(out RaycastHit hitinfo))
        {
            Damageable damageable = hitinfo.collider.GetComponent<Damageable>();
            if (damageable != null && !hitinfo.collider.CompareTag(transform.root.tag))
            {
                damageable.TakeDame(dame);
                owner?.AddDameDealt(dame);
                Destroy(gameObject);
            }
        }
    }

    internal void SetOwner(Player owner)
    {
        this.owner = owner;
    }

    private bool IsNextFrameHit(out RaycastHit hitinfo)
    {
        return Physics.Raycast(transform.position, transform.forward, out hitinfo, speed * Time.fixedDeltaTime, whatCanBeHit, QueryTriggerInteraction.Ignore);
    }
}
