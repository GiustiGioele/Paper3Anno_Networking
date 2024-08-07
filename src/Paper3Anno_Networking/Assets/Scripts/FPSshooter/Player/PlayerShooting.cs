using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace FPShooter
{
    public class PlayerShooting : NetworkBehaviour
    {
        [Header("Gun")]
        public int gunDamage;
        public float distanceRange;
        public Camera cam;
        public ParticleSystem muzzleFlash;
        public ParticleSystem impactEffect;
        public float impactForce;

        public void Shooting()
        {
            if (!IsOwner) return;
        ShootServerRpc();
        }

        [ServerRpc] private void ShootServerRpc(ServerRpcParams rpcParams = default)
        {
            ShootClientRpc();
            ShootingEnemy();
            ShootingTarget();
        }

        [ClientRpc]
        private void ShootClientRpc(ClientRpcParams rpcParams = default)
        {
            muzzleFlash.Play();
        }

        public void ShootingEnemy()
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distanceRange)) {
                Debug.DrawRay(cam.transform.position, cam.transform.forward, Color.green);
                Debug.Log(hit.collider.name);
                Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();
                if (enemy != null) {
                    EventBus.Publish(new EnemyTakesDamageEvent(gunDamage));
                    Debug.Log("damage" + gunDamage);
                }
                if (hit.rigidbody != null) {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }
                Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }

        public void ShootingTarget()
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distanceRange)) {
                Debug.DrawRay(cam.transform.position,cam.transform.forward, Color.green);
                Debug.Log(hit.collider.name);
                Target target = hit.collider.gameObject.GetComponent<Target>();
                if (target != null) {
                    target.TargetTakeDamage(gunDamage);
                    Debug.Log("damage " + gunDamage);
                }

                if (hit.rigidbody != null) {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }
                Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
    }
}

