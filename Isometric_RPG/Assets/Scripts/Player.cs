﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, Damageable
{
    public float speed;
    public float gravity;
    public float turnSmoothTime;
    public float health;
    private float fallSpeed;
    private CharacterController controller;
    private float faceAngle;
    private float turnSmoothVelocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        Debug.Log(transform.root.tag);
    }

    private void Update()
    {
        Vector2 inputDir = GetPlayerInput();
        fallSpeed = controller.isGrounded ? 0 : fallSpeed + (gravity * Time.deltaTime);
        controller.Move(GetVelocity(inputDir, fallSpeed) * Time.deltaTime);

        if (inputDir != Vector2.zero)
        {
            float target = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
            faceAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target, ref turnSmoothVelocity, turnSmoothTime);
            transform.eulerAngles = new Vector3(0, faceAngle, 0);
        }

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

    public void TakeDame(float dame)
    {
        if (health > 0)
            health -= dame;
        else
            Debug.Log("You DIE!");
    }
}