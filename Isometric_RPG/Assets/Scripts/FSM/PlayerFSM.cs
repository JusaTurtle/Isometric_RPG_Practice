using UnityEngine;

public class PlayerFSM : FSM
{
    public Gun weapon;
    public float dashDistance;
    public CharacterController controller;

    public override void Attack(int type)
    {
        weapon.PerformAttack(type);
    }

    public override void Dash(Vector2 dir)
    {
        transform.Translate(new Vector3(dir.x, 0f, dir.y) * dashDistance);
    }

    public override void Move(Vector2 velocity)
    {
        controller.Move(new Vector3(velocity.x, controller.velocity.y, velocity.y));
    }

    public override void Turn(float faceAngle)
    {
        transform.eulerAngles = new Vector3(0f, faceAngle, 0f);
    }
}