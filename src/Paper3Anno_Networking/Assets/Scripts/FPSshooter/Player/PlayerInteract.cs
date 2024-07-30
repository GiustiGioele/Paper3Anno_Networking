using UnityEngine;

namespace FPShooter
{
    public class PlayerInteract : MonoBehaviour
    {
        [SerializeField] private float distance;
        private PlayerLook _look;
        private PlayerUI _playerUI;
        private InputManager _inputManager;
        private PlayerHealthBar _healthBar;

        private void Awake()
        {
            _look = GetComponent<PlayerLook>();
            _playerUI = GetComponent<PlayerUI>();
            _inputManager = GetComponent<InputManager>();
            _healthBar = GetComponent<PlayerHealthBar>();
        }

        private void Update() => PlayerInteractRay();

        private void PlayerInteractRay()
        {
            _playerUI.UpdateText(string.Empty);

            var ray = new Ray(_look.transform.position, _look.transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.magenta);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray.origin, ray.direction, out raycastHit, distance)) {
                if (raycastHit.collider.GetComponent<Interactable>() != null) {
                    var interactable = raycastHit.collider.GetComponent<Interactable>();
                    _playerUI.UpdateText(interactable.prompt);
                    if (_inputManager._playerMovementsActions.Interact.triggered) {
                        int damage = interactable.interactableDamage;
                        _healthBar.TakeDamageBar(damage);
                        interactable.InvokeDamage();
                        Debug.Log("OnDamage");
                    }
                }
            }
        }
    }
}
