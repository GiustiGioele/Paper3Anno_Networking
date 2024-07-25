using System;
using System.Collections;
using System.Collections.Generic;
using FPSshooter;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private float distance;
    private PlayerUI _playerUI;
    private void Start()
    {
        _cam = GetComponent<PlayerLook>().cam;
        _playerUI = GetComponent<PlayerUI>();
    }

    private void Update()
    {
        _playerUI.UpdateText(String.Empty);
        Ray ray = new Ray(_cam.transform.position, _cam.transform.forward);
        Debug.DrawRay(ray.origin,ray.direction * distance,Color.magenta);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray.origin,ray.direction , out raycastHit, distance)) {
            if (raycastHit.collider.GetComponent<Interactable>() != null) {
                _playerUI.UpdateText(raycastHit.collider.GetComponent<Interactable>().prompt);
            }
        }
    }
}
