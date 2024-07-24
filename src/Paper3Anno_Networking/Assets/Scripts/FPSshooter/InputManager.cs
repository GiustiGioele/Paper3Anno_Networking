using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FPSshooter
{
    public class InputManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerInput.PlayerMovementsActions _playerMovementsActions;
    private PlayerMotor _motor;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerMovementsActions = _playerInput.PlayerMovements;
        _motor = GetComponent<PlayerMotor>();
        _playerMovementsActions.Jump.performed += ctx => _motor.Jump();
    }

    private void FixedUpdate()
    {
        //tell the player to move using the value from our movement action
        _motor.ProcessMove(_playerMovementsActions.Movement.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        _playerMovementsActions.Enable();
    }

    private void OnDisable()
    {
        _playerMovementsActions.Disable();
    }
}
}
