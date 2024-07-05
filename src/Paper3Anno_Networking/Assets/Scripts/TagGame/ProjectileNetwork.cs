using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class ProjectileNetwork : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectilePoint;
    public float speed;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            HandleShooting();
        }
    }

    private void HandleShooting()
    {
        Instantiate(projectile, projectilePoint.position, projectilePoint.rotation);
        projectile.GetComponent<Rigidbody>().velocity = projectilePoint.forward * speed;
    }

}
