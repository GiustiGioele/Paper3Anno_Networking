using UnityEngine;
using Unity.Netcode;

namespace FPShooter
{
    public class InputManager : NetworkBehaviour
    {
        private PlayerInput _playerInput;
        internal PlayerInput.PlayerMovementsActions _playerMovementsActions;
        private PlayerMotor _motor;
        private PlayerLook _look;
        private PlayerShooting _shooting;

        private void Awake()
        {
            _playerInput = new PlayerInput();
            _playerMovementsActions = _playerInput.PlayerMovements;
            _motor = GetComponent<PlayerMotor>();
            _look = GetComponent<PlayerLook>();
            _shooting = GetComponent<PlayerShooting>();

            _playerMovementsActions.Jump.performed += ctx => _motor.Jump();
            _playerMovementsActions.Crouch.performed += ctx => _motor.Crouch();
            _playerMovementsActions.Sprint.performed += ctx => _motor.Sprint();
            _playerMovementsActions.Shooting.performed += ctx => _shooting.Shooting();
        }

        private void FixedUpdate()
        {
            if (!IsOwner) return;
            //tell the player to move using the value from our movement action
            _motor.ProcessMove(_playerMovementsActions.Movement.ReadValue<Vector2>());
        }

        private void LateUpdate()
        {
            if (!IsOwner) return;
            _look.ProcessLook(_playerMovementsActions.Look.ReadValue<Vector2>());
        }

        private void OnEnable()
        {
            if (IsOwner)
            {
                _playerMovementsActions.Enable();
            }
        }

        private void OnDisable()
        {
            if (IsOwner)
            {
                _playerMovementsActions.Disable();
            }
        }
    }
}
