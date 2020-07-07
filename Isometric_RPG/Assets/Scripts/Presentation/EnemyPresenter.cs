using System;
using UnityEngine;

public class EnemyPresenter : MonoBehaviour, Damageable
{
    public Gun weapon;
    public float sqrAttackRange;
    public float speed;
    public float turnSmoothTime;
    public int health;
    private Enemy enemy;

    private void Start()
    {
        enemy = new Enemy
        {
            weapon = weapon,
            sqrAttackRange = sqrAttackRange,
            speed = speed,
            turnSmoothTime = turnSmoothTime,
            health = health,
            mover = new MoveByController(GetComponent<CharacterController>()),
            transformer = new DefaultTransform(transform),
        };

        enemy.SetTarget(GameObject.FindGameObjectWithTag("Player").transform);
    }

    private void Update()
    {
        enemy.Update();
    }

    public void TakeDame(int dame)
    {
        health -= dame;
        if (health <= 0)
        {
            enemy.Die();
            Destroy(gameObject);
        }
    }
}