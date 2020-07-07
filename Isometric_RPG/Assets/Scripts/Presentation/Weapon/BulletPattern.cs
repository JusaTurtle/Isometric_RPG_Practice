using System;
using UnityEngine;

public class BulletPattern : MonoBehaviour {
    public float lifeTime;
    private float timer;
    public Bullet[] bullets;

    private void Start() {
        timer = lifeTime;
    }

    private void Update() {
        if((timer -= Time.deltaTime) <= 0)
        {
            Destroy(gameObject);
        }
    }

    internal void SetOwner(Player owner)
    {
        foreach(Bullet b in bullets)
        {
            b.SetOwner(owner);
        }
    }
}