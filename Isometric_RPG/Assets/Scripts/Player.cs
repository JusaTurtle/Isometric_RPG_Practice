using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    public float maxDistance;
    public LayerMask whatIsGround;
    private Camera cam;
    public Gun weapon;
    public KeyCode basic;
    public KeyCode special;
    private int dameDealt;
    public GameManager mng;

    public int DameDealt { get => dameDealt; set => dameDealt = value; }

    private void Start()
    {
        cam = Camera.main;
        weapon.SetOwner(this);
    }

    private void Update() {
        base.Update();
        weapon.Attack(GetAction());
    }

    public override Vector2 GetMoveDir()
    {
        // if (Input.GetMouseButton(0) || Input.GetMouseButton(1)) return Vector2.zero;
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    public override void Die()
    {
        mng.GameOver();
    }

    protected override Vector2 GetRotDir()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            new Plane(Vector3.up, transform.position).Raycast(ray, out float enter);
            Vector3 dir = ray.GetPoint(enter) - transform.position;
            return new Vector2(dir.x, dir.z);
        }
        else
        {
            return GetMoveDir();
        }
    }

    public void AddDameDealt(int dame)
    {
        DameDealt += dame;
    }

    protected override float Turn(float target)
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1)) return target;
        else return base.Turn(target);
    }

    private char GetAction()
    {
        if (Input.GetKey(basic)) return 'b';
        if (Input.GetKey(special)) return 's';
        return ' ';
    }
}
