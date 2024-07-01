using Unity.Netcode;
using UnityEngine;
public class PlayerMovement : NetworkBehaviour
{
    public float speed;

    private void Update()
    {
        if (IsOwner) {
            return;
        }

        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            transform.Translate(movement * (speed * Time.deltaTime));
        }
    }
}
