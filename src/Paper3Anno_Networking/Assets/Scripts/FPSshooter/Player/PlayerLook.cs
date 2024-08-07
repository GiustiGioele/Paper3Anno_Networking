using System;
using Unity.Netcode;
using UnityEngine;

namespace FPShooter
{
    public class PlayerLook : NetworkBehaviour
    {
        private NetworkVariable<Quaternion> _networkRotation = new NetworkVariable<Quaternion>();
        public Camera cam;
        private float _xRotation;

        public float xSensitivity;
        public float ySensitivity;

        private void Update()
        {
            if (!IsOwner) {
                transform.rotation = _networkRotation.Value;
            }
        }

        public void ProcessLook(Vector2 input)
        {
            if (!IsOwner) return;
            float mouseX = input.x;
            float mouseY = input.y;
            //calculate the camera rotation for looking up and down
            _xRotation -= mouseY * Time.deltaTime * ySensitivity;
            _xRotation = Mathf.Clamp(_xRotation, -80f, 80f);
            //apply this to our camera transform
            cam.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
            //rotate the player to look left and right
            transform.Rotate(Vector3.up * (mouseX * Time.deltaTime * xSensitivity));
        }
    }
}
