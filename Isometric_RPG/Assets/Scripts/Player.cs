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

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update() {
        base.Update();
        weapon.Attack(GetAction());
    }

    public override Vector2 GetMoveDir()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1)) return Vector2.zero;
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    public override void Die()
    {
        Debug.Log("You DIE!");
    }

    protected override Vector2 GetRotDir()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo, maxDistance, whatIsGround);
            Vector3 dir = hitInfo.point - transform.position;
            return new Vector2(dir.x, dir.z);
        }
        else
        {
            return GetMoveDir();
        }
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
