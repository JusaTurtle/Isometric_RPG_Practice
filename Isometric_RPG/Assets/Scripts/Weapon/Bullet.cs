﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage;

    private void Start()
    {
        DetectHit();
        Debug.Log(transform.root.tag);
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
            Debug.Log(hitinfo.collider.tag, this);
            if (damageable != null && !hitinfo.collider.CompareTag(transform.root.tag))
            {
                damageable.TakeDame(damage);
                Destroy(gameObject);
            }
            else if (hitinfo.collider?.CompareTag(transform.root.tag) == false)
            {
                Destroy(gameObject);
            }
        }
    }

    private bool IsNextFrameHit(out RaycastHit hitinfo)
    {
        return Physics.Raycast(transform.position, transform.forward, out hitinfo, speed * Time.fixedDeltaTime);
    }
}