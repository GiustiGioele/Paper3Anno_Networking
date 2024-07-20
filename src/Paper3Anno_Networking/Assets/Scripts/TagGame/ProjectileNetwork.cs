using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class ProjectileNetwork : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Shooting();
        }
    }

    private void Shooting()
    {
        GameObject clone = Instantiate(projectile, firePoint.position, firePoint.rotation);
    }
}
