using UnityEngine;

namespace FPSshooter
{
    public class PlayerLook : MonoBehaviour
    {
        public Camera cam;
        private float _xRotation;

        public float xSensitivity;
        public float ySensitivity;

        public void ProcessLook(Vector2 input)
        {
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
