using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPresenter : MonoBehaviour, Damageable
{
    public float speed;
    public float turnSmoothTime;
    public int health;
    public LayerMask whatIsGround;
    public KeyCode basic;
    public Movable controller;
    public Gun weapon;
    private Player player;
    public GameManager mng;

    public void TakeDame(int dame)
    {
        health -= dame;
        if(health <= 0)
        {
            mng.GameOver();
            player.Die();
        }
    }

    private void Start()
    {
        player = new Player
        {
            speed = speed,
            turnSmoothTime = turnSmoothTime,
            health = health,
            whatIsGround = whatIsGround,
            basic = basic,
            mover = new MoveByController(GetComponent<CharacterController>()),
            transformer = new DefaultTransform(transform),
            cam = Camera.main
        };
        player.Equip(weapon);
    }

    private void Update()
    {
        player.Update();
    }

    public int GetDameDealt()
    {
        return player.DameDealt;
    }
}