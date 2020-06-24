using UnityEngine;

public class BulletPattern : MonoBehaviour {
    public float lifeTime;
    private float timer;

    private void Start() {
        timer = lifeTime;
    }

    private void Update() {
        if((timer -= Time.deltaTime) <= 0)
        {
            Destroy(gameObject);
        }
    }
}