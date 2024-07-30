using System;
using UnityEngine;
using UnityEngine.UI;

namespace FPShooter
{
    public class PlayerHealthBar : MonoBehaviour
    {
        private float _lerpTimer;
        private int _currentHealthBar;

        [Header("Health Bar")]
        [SerializeField] private int maxHealthBar;
        [SerializeField] private float barSpeed;
        [SerializeField] private Image frontBar;
        [SerializeField] private Image backBar;

        private void Start()
        {
            Interactable interactable = FindObjectOfType<Interactable>();
            if (interactable != null)
            {
                interactable.OnDamage += TakeDamageBar;
                Debug.Log("PlayerHealthBar is subscribed to OnDamage");
            }
            _currentHealthBar = maxHealthBar;
        }

        private void Update()
        {
            _currentHealthBar = Mathf.Clamp(_currentHealthBar, 0, maxHealthBar);
            UpdateBar();
        }

        private void UpdateBar()
        {
            float fillF = frontBar.fillAmount;
            float fillB = backBar.fillAmount;
            float hFraction = (float)_currentHealthBar / maxHealthBar;  // Conversione a float

            // Aggiornamento quando la barra posteriore è maggiore della salute corrente
            if (fillB > hFraction)
            {
                frontBar.fillAmount = hFraction;
                backBar.color = Color.red;
                _lerpTimer += Time.deltaTime;
                float percentComplete = _lerpTimer / barSpeed;
                percentComplete = percentComplete * percentComplete;
                backBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
            }

            // Aggiornamento quando la barra posteriore è minore della salute corrente
            if (fillB < hFraction)
            {
                backBar.color = Color.green;
                backBar.fillAmount = hFraction;
                _lerpTimer += Time.deltaTime;
                float percentComplete = _lerpTimer / barSpeed;
                percentComplete = percentComplete * percentComplete;
                frontBar.fillAmount = Mathf.Lerp(fillF, backBar.fillAmount, percentComplete);
            }
        }

        public void TakeDamageBar(int damage)
        {
            if (_currentHealthBar <= 0)
            {
                Debug.Log("Player is already at 0 health. No further damage can be taken.");
                return;
            }
            _currentHealthBar -= damage;
            _currentHealthBar = Mathf.Clamp(_currentHealthBar, 0, maxHealthBar);  // Clamp subito dopo aver ridotto
            Debug.Log($"Player HealthBar took {damage} damage, current life is: {_currentHealthBar}");
            _lerpTimer = 0f;  // Reset del timer
        }

        public void ResetHealthBar(int healAmount)
        {
            _currentHealthBar += healAmount;
            _currentHealthBar = Mathf.Clamp(_currentHealthBar, 0, maxHealthBar);  // Clamp per sicurezza
            _lerpTimer = 0f;  // Reset del timer
        }
    }
}
