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
    private InputManager _inputManager;
    private void Start()
    {
        _cam = GetComponent<PlayerLook>().cam;
        _playerUI = GetComponent<PlayerUI>();
        _inputManager = GetComponent<InputManager>();
    }

    private void Update()
    {
        _playerUI.UpdateText(String.Empty);

        Ray ray = new Ray(_cam.transform.position, _cam.transform.forward);
        Debug.DrawRay(ray.origin,ray.direction * distance,Color.magenta);
        RaycastHit raycastHit;

        if (Physics.Raycast(ray.origin,ray.direction , out raycastHit, distance)) {
            if (raycastHit.collider.GetComponent<Interactable>() != null) {
                Interactable interactable = raycastHit.collider.GetComponent<Interactable>();

                _playerUI.UpdateText(interactable.prompt);
                if (_inputManager._playerMovementsActions.Interact.triggered) {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
