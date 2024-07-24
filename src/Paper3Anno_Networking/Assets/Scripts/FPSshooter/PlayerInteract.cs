using System;
using System.Collections;
using System.Collections.Generic;
using FPSshooter;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private float distance;
    private void Start()
    {
        _cam = GetComponent<PlayerLook>().cam;
    }

    private void Update()
    {
        Ray ray = new Ray(_cam.transform.position, _cam.transform.forward);
        Debug.DrawRay(ray.origin,ray.direction * distance,Color.magenta);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray.origin,ray.direction , out raycastHit, distance)) {
            if (raycastHit.collider.GetComponent<Interactable>() != null) {
                Debug.Log(raycastHit.collider.GetComponent<Interactable>().prompt);
            }
        }
    }
}
