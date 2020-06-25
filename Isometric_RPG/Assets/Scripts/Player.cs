using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    public override Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    public override void Die()
    {
        Debug.Log("You DIE!");
    }
}
