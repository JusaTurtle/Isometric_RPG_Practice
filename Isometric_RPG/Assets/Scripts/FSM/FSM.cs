
using UnityEngine;

public abstract class FSM : MonoBehaviour
{
    private State current;

    public void Left() => current.Left(this);
    public void Right() => current.Right(this);
    public void Top() => current.Top(this);
    public void Down() => current.Down(this);
    public void BasicAttack() => current.BasicAttack(this);

    public abstract void Move(Vector2 velocity);
    public abstract void Dash(Vector2 dir);
    public abstract void Turn(float faceAngle);
    public abstract void Attack(int type);
}