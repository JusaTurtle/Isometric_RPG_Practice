using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    public int whatIsGround;
    public KeyCode basic;
    public Camera cam;
    private Gun weapon;
    private int dameDealt;

    public int DameDealt { get => dameDealt; set => dameDealt = value; }

    public void Update()
    {
        base.Update();
        weapon.Attack(GetAction());
    }

    public override Vector2 GetMoveDir()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    public override void Die()
    {
        
    }

    protected override Vector2 GetRotDir()
    {
        if (Input.GetKey(basic))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            new Plane(Vector3.up, transformer.GetPos()).Raycast(ray, out float enter);
            Vector3 dir = ray.GetPoint(enter) - transformer.GetPos();
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

    protected override void Turn(float target)
    {
        if (Input.GetKey(basic)) transformer.RotateTo(target);
        else base.Turn(target);
    }

    private char GetAction()
    {
        if (Input.GetKey(basic)) return 'b';
        return ' ';
    }

    public void Equip(Gun weapon)
    {
        this.weapon = weapon;
        this.weapon.SetOwner(this);
    }
}
