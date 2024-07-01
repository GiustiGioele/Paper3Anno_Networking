using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.netcode;

public class PlayerMovement : NetworkBehaviour
{
   public float speed;

    private void Update()
    {
        if (IsOwner)  return;
        {

            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            transform.Translate(movement * speed * time.deltaTime);
        }
    }

}
