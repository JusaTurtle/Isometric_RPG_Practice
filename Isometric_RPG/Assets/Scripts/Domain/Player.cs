using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    public LayerMask whatIsGround;
    public KeyCode basic;
    public GameManager mng;
    public Camera cam;
    public Gun weapon;
    private int dameDealt;

    public int DameDealt { get => dameDealt; set => dameDealt = value; }

    public void Update() {
        base.Update();
        weapon.Attack(GetAction());
    }

    public override Vector2 GetMoveDir()
    {
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
        return ' ';
    }
}
