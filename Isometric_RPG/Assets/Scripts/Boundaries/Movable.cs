using UnityEngine;

public interface Movable
{
    void Move(Vector3 motion);
    bool IsGrounded{get;}
}