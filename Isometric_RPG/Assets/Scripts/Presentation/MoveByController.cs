using UnityEngine;

public class MoveByController : Movable
{
    private CharacterController controller;

    public MoveByController(CharacterController controller)
    {
        this.controller = controller;
    }

    public void Move(Vector3 motion)
    {
        controller.Move(motion);
    }

    public bool IsGrounded
    {
        get => controller.isGrounded;
    }
}