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
    public ScoreDisplayer scoreDisplayer;

    public Player Player { get => player; }

    public void TakeDame(int dame)
    {
        health -= dame;
        if(health <= 0)
        {
            scoreDisplayer.GameOver();
            Player.Die();
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
            cam = Camera.main,
            sm = scoreDisplayer.Manager
        };
        Player.Equip(weapon);
    }

    private void Update()
    {
        Player.Update();
    }
}