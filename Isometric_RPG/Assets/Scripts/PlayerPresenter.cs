using System;
using UnityEngine;

public class PlayerPresenter : MonoBehaviour, Damageable
{
    public float speed;
    public float turnSmoothTime;
    public int health;
    public LayerMask whatIsGround;
    public KeyCode basic;
    public GameManager mng;
    public CharacterController controller;
    public Gun weapon;
    private Player player;

    public void TakeDame(int dame)
    {
        health -= dame;
        if(health <= 0)
        {
            player.Die();
        }
    }

    internal int GetDameDealt()
    {
        return player.DameDealt;
    }

    private void Start()
    {
        player = new Player
        {
            speed = speed,
            turnSmoothTime = turnSmoothTime,
            health = health,
            whatIsGround = whatIsGround,
            weapon = weapon,
            basic = basic,
            mng = mng,
            controller = controller,
            transform = transform,
            cam = Camera.main
        };
        weapon.SetOwner(player);
    }

    private void Update()
    {
        player.Update();
    }

}