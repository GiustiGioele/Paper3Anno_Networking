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

        private void Update() => PlayerInteractRay();

        private void PlayerInteractRay()
        {
            _playerUI.UpdateText(string.Empty);

            var ray = new Ray(_cam.transform.position, _cam.transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.magenta);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray.origin, ray.direction, out raycastHit, distance)) {
                if (raycastHit.collider.GetComponent<Interactable>() != null) {
                    Interactable interactable = raycastHit.collider.GetComponent<Interactable>();
                    _playerUI.UpdateText(interactable.promptMessage);
                    if (_inputManager._playerMovementsActions.Interact.triggered) {
                        int damage = interactable.interactableDamage;
                        interactable.OnDamage += _playerStats.TakeDamage;
                        interactable.OnDamage += _healthBar.TakeDamageBar;
                        interactable.InvokeDamage();
                        Debug.Log("OnDamage");
                        interactable.OnDamage -= _playerStats.TakeDamage;
                        interactable.OnDamage -= _healthBar.TakeDamageBar;
                    }
                }
            }
        }
    }
}
