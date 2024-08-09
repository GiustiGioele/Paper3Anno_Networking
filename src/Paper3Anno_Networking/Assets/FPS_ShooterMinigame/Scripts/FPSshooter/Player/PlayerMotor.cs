using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using Unity.Netcode;

namespace FPShooter
{
    public class PlayerMotor : NetworkBehaviour
    {
        private NetworkVariable<Vector3> _networkPosition = new NetworkVariable<Vector3>();
        private CharacterController _controller;
        private Vector3 _playerVelocity;
        private bool _isGrouned;
        private bool _lerpCrouch;
        private bool _crouching;
        private float _crouchTimer;
        private bool _sprinting;

        private float _gravity = -9.8f;
        [SerializeField] private float speed;
        [SerializeField] private float jumpHeight;


        private void Start() => _controller = GetComponent<CharacterController>();

        private void Update()
        {
            if (!IsOwner) {
                transform.position = _networkPosition.Value;
            }
            _isGrouned = _controller.isGrounded;
            if (_lerpCrouch) {
                _crouchTimer += Time.deltaTime;
                float p = _crouchTimer / 1;
                p *= p;
                if (_crouching) {
                    _controller.height = Mathf.Lerp(_controller.height, 1, p);
                }
                else {
                    _controller.height = Mathf.Lerp(_controller.height, 2, p);
                }

                if (p > 1) {
                    _lerpCrouch = false;
                    _crouchTimer = 0f;
                }
            }
        }

        //this method receives inputs from our InputManager and apply them to character controller
        public void ProcessMove(Vector2 input)
        {
            if (!IsOwner) return;
            Vector3 moveDirection = Vector3.zero;
            moveDirection.x = input.x;
            moveDirection.z = input.y;
            _controller.Move(transform.TransformDirection(moveDirection.x, 0, moveDirection.z) *
                             (speed * Time.deltaTime));
            // Debug.Log("current speed is " + speed);
            _playerVelocity.y += _gravity * Time.deltaTime;
            if (_isGrouned && _playerVelocity.y < 0) {
                _playerVelocity.y = -2;
            }

            _controller.Move(_playerVelocity * Time.deltaTime);
            Debug.Log(_playerVelocity.y);
        }

        public void Jump()
        {
            if (!IsOwner) return;
            if (_isGrouned) {
                _playerVelocity.y = (float)Math.Sqrt(jumpHeight * -jumpHeight * _gravity);
            }
        }

        public void Crouch()
        {
            if (!IsOwner) return;
            _crouching = !_crouching;
            _crouchTimer = 0f;
            _lerpCrouch = true;
        }

        public void Sprint()
        {
            if (!IsOwner) return;
            _sprinting = !_sprinting;
            if (_sprinting) {
                speed = 8f;
            }
            else {
                speed = 5f;
            }
        }


    }

}
