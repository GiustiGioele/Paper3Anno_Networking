using System;
using System.Collections;
using System.Collections.Generic;
using FPSshooter;
using UnityEngine;

namespace FPShooter
{
    public class Bullet : MonoBehaviour
    {

        private void OnCollisionEnter(Collision collision)
        {
            Transform hitTransform = collision.transform;
            if (hitTransform.CompareTag("Player")) {
                Debug.Log("hit player");

            }
            Destroy(gameObject);
        }
    }
}
