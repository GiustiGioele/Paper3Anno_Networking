using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;


    private void Update()
    {
        if (!IsOwner) {
            return;
        }

        HandleMovement();
    }


    private void HandleMovement()
    {
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            var movementDirection = new Vector3(moveHorizontal, 0, moveVertical);
            movementDirection.Normalize();

            transform.Translate(movementDirection * (movementSpeed * Time.deltaTime), Space.World);

            if (movementDirection != Vector3.zero) {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation =
                    Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
