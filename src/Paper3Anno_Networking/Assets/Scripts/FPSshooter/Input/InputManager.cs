using UnityEngine;

namespace FPSshooter
{
    public class InputManager : MonoBehaviour
    {
        private PlayerInput _playerInput;
        internal PlayerInput.PlayerMovementsActions _playerMovementsActions;
        private PlayerMotor _motor;
        private PlayerLook _look;

        private void Awake()
        {
            _playerInput = new PlayerInput();
            _playerMovementsActions = _playerInput.PlayerMovements;
            _motor = GetComponent<PlayerMotor>();
            _look = GetComponent<PlayerLook>();

            _playerMovementsActions.Jump.performed += ctx => _motor.Jump();
            _playerMovementsActions.Crouch.performed += ctx => _motor.Crouch();
            _playerMovementsActions.Sprint.performed += ctx => _motor.Sprint();
            _playerMovementsActions.Shooting.performed += ctx => _motor.Shooting();
        }

        private void FixedUpdate() =>
            //tell the player to move using the value from our movement action
            _motor.ProcessMove(_playerMovementsActions.Movement.ReadValue<Vector2>());

        private void LateUpdate() => _look.ProcessLook(_playerMovementsActions.Look.ReadValue<Vector2>());

        private void OnEnable() => _playerMovementsActions.Enable();

        private void OnDisable() => _playerMovementsActions.Disable();
    }
}
