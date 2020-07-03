using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour, Damageable
{
    public float speed;
    public float gravity;
    public float turnSmoothTime;
    public int health;
    private float fallSpeed;
    private CharacterController controller;
    private float faceAngle;
    private float turnSmoothVelocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public void Update()
    {
        Vector2 inputDir = GetMoveDir();
        fallSpeed = controller.isGrounded ? 0 : fallSpeed + (gravity * Time.deltaTime);
        controller.Move(GetVelocity(inputDir, fallSpeed) * Time.deltaTime);

        Vector2 inputRot = GetRotDir();
        if (inputRot != Vector2.zero)
        {
            float target = CalculateFaceAngle(inputRot);
            faceAngle = Turn(target);
            transform.eulerAngles = new Vector3(0, faceAngle, 0);
        }
    }

    protected virtual float Turn(float target)
    {
        return Mathf.SmoothDampAngle(transform.eulerAngles.y, target, ref turnSmoothVelocity, turnSmoothTime);
    }

    private float CalculateFaceAngle(Vector2 inputRot)
    {
        return Mathf.Atan2(inputRot.x, inputRot.y) * Mathf.Rad2Deg;
    }

    private Vector3 GetVelocity(Vector2 inputDir, float fallSpeed)
    {
        return CalculateOnGroundVelocity(inputDir.normalized) + CalculateFallVelocity(fallSpeed);
    }

    private Vector3 CalculateFallVelocity(float fallSpeed)
    {
        return fallSpeed * Vector3.down * speed;
    }

    private Vector3 CalculateOnGroundVelocity(Vector2 inputDir)
    {
        return ((inputDir.x * Vector3.right) + (inputDir.y * Vector3.forward)) * speed;
    }

    public void TakeDame(int dame)
    {
        if (health - dame <= 0)
        {
            Die();
        }
        else
        {
            health -= dame;
        }
    }

    protected abstract Vector2 GetRotDir();
    public abstract Vector2 GetMoveDir();
    public abstract void Die();
}
