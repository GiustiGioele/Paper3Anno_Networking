
using System;
using FPSshooter;
using UnityEngine;

namespace FPShooter
{
    public class Bullet : MonoBehaviour
    {
        public int bulletDamage;
        private void OnCollisionEnter(Collision collision)
        {
            Transform hitTransform = collision.transform;
            if (hitTransform.CompareTag("Player")) {
                Debug.Log("hit player");
                EventBus.Publish(new PlayerTakesDamageEvent(bulletDamage));
            }
            Destroy(gameObject);
        }
    }
}
