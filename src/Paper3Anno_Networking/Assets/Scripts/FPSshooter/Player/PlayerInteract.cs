using System;
using System.Collections;
using System.Collections.Generic;
using FPSshooter;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerInteract : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private float distance;
    private PlayerUI _playerUI;
    private InputManager _inputManager;
    private PlayerHealthBar _healthBar;
    private void Start()
    {
        _cam = GetComponent<PlayerLook>().cam;
        _playerUI = GetComponent<PlayerUI>();
        _inputManager = GetComponent<InputManager>();
        _healthBar = GetComponent<PlayerHealthBar>();
    }

    private void Update()
    {
        _playerUI.UpdateText(promptMessage: String.Empty);

        Ray ray = new Ray(origin: _cam.transform.position, direction: _cam.transform.forward);
        Debug.DrawRay(start: ray.origin,dir: ray.direction * distance,color: Color.magenta);
        RaycastHit raycastHit;

        if (Physics.Raycast(origin: ray.origin,direction: ray.direction , hitInfo: out raycastHit, maxDistance: distance)){
            if (raycastHit.collider.GetComponent<Interactable>() != null) {
                Interactable interactable = raycastHit.collider.GetComponent<Interactable>();
                _playerUI.UpdateText(promptMessage: interactable.prompt);
                if (_inputManager._playerMovementsActions.Interact.triggered) {
                    float damage = interactable.interactableDamage;
                    _healthBar.TakeDamage(damage);
                    interactable.InvokeDamage();
                    Debug.Log(message: "OnDamage");
                }
            }
        }
    }
}
