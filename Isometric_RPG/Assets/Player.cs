using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float gravity;
    private float fallSpeed;
    private CharacterController controller;

    private void Awake() {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector2 inputDir = GetPlayerInput();
        fallSpeed = controller.isGrounded ? 0 : fallSpeed + (gravity * Time.deltaTime);
        controller.Move(GetVelocity(inputDir, fallSpeed) * Time.deltaTime);
    }

    private static Vector2 GetPlayerInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    private Vector3 GetVelocity(Vector2 inputDir, float fallSpeed)
    {
        return CalculateOnGroundVelocity(inputDir) + CalculateFallVelocity(fallSpeed);
    }

    private Vector3 CalculateFallVelocity(float fallSpeed)
    {
        return fallSpeed * Vector3.down * speed;
    }

    private Vector3 CalculateOnGroundVelocity(Vector2 inputDir)
    {
        return ((inputDir.x * Vector3.right) + (inputDir.y * Vector3.forward)) * speed;
    }
}
