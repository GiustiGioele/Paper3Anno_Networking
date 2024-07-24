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
    private bool _isGrouned;
    private float _gravity = -9.8f;
    public float speed;
    public float jumpHeight;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _isGrouned = _controller.isGrounded;
    }

    //this method receives inputs from our InputManager and apply them to character controller
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        _controller.Move(transform.TransformDirection(moveDirection.x, 0, moveDirection.z) * (speed * Time.deltaTime));
        _playerVelocity.y += _gravity * Time.deltaTime;
        if (_isGrouned && _playerVelocity.y < 0) {
            _playerVelocity.y = -2;
        }
        _controller.Move(_playerVelocity * Time.deltaTime);
        Debug.Log(_playerVelocity.y);
    }

    public void Jump()
    {
        if (_isGrouned) {
            _playerVelocity.y = (float)Math.Sqrt(jumpHeight * -jumpHeight * _gravity);
        }
    }
}
}
