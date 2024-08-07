using System;
using UnityEngine;

namespace FPShooter
{
    public class PlayerInteract : MonoBehaviour
    {
        [SerializeField] private float distance;
        private Camera _cam;
        private PlayerUI _playerUI;
        private InputManager _inputManager;
        private PlayerHealthBar _healthBar;
        private PlayerStats _playerStats;
        private void Awake()
        {
            _cam = GetComponent<PlayerLook>().cam;
            _playerUI = GetComponent<PlayerUI>();
            _inputManager = GetComponent<InputManager>();
            _healthBar = GetComponent<PlayerHealthBar>();
            _playerStats = GetComponent<PlayerStats>();
        }

        private void OnEnable()
        {
            EventBus.Subscribe<PlayerTakesDamageEvent>(HandleDamageEvent);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe<PlayerTakesDamageEvent>(HandleDamageEvent);
        }

        private void Update() => PlayerInteractRay();

        private void PlayerInteractRay()
        {
            _playerUI.UpdateText(string.Empty, String.Empty);

            var ray = new Ray(_cam.transform.position, _cam.transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.magenta);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray.origin, ray.direction, out raycastHit, distance)) {
                if (raycastHit.collider.GetComponent<Interactable>() != null) {
                    Interactable interactable = raycastHit.collider.GetComponent<Interactable>();
                    _playerUI.UpdateText(interactable.promptMessage, null);
                    if (_inputManager._playerMovementsActions.Interact.triggered) {
                        interactable.InvokeDamage();
                        Debug.Log("OnDamage");
                    }
                }
            }

            if (Physics.Raycast(ray.origin, ray.direction, out raycastHit, distance)) {
                if (raycastHit.collider.GetComponent<Enemy>() != null) {
                    Enemy enemy = raycastHit.collider.GetComponent<Enemy>();
                    _playerUI.UpdateText(null, enemy.enemyPromptMessage);
                }
            }
        }

        private void HandleDamageEvent(PlayerTakesDamageEvent e)
        {
            int damage = e._damageAmount;
            _playerStats.TakeDamage(e);
            _healthBar.TakeDamageBar(e);
            Debug.Log($"Handled damage event with {damage} damage");
        }
    }
}
