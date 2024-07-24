using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPSshooter
{


public class PlayerMotor : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _playerVelocity;
    public float speed;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    //this method receives inputs from our InputManager and apply them to character controller
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        _controller.Move(transform.TransformDirection(moveDirection.x, 0, moveDirection.z) * speed * Time.deltaTime);
    }
}
}
