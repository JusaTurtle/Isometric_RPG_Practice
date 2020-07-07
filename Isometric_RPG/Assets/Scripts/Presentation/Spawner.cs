using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public EnemyPresenter[] enemies;
    public float innerRange;
    public float outterRange;
    public float delay;
    public LayerMask whatIsGround;
    private GameObject player;
    private float timer;

    private void Start()
    {
        timer = delay;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(player == null) return;
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            float r = Random.Range(innerRange, outterRange);
            float x = Random.Range(0f, r) * GetRandomSign();
            float z = Mathf.Sqrt(Mathf.Pow(r, 2) - Mathf.Pow(x, 2)) * GetRandomSign();
            Vector3 pos = new Vector3(x, 100, z) + player.transform.position;
            if (Physics.Raycast(pos, Vector3.down, out RaycastHit hitInfo, 200, whatIsGround, QueryTriggerInteraction.Ignore))
            {
                EnemyPresenter enemy = Instantiate(enemies[Random.Range(0, enemies.Length)], hitInfo.point, Quaternion.identity) as EnemyPresenter;
                timer = delay;
            }
        }
    }

    private static int GetRandomSign()
    {
        return (Random.Range(0, 2) * 2) - 1;
    }
}
