using UnityEngine;
using UnityEngine.UI;

namespace FPShooter
{
    public class PlayerHealthBar : MonoBehaviour
    {
        private bool _isTakingDamage;
        private int _damageAmount;

        private float _lerpTimer;
        private int _currentHealthBar;

        [Header("Health Bar")] [SerializeField]
        private int maxHealthBar;

        [SerializeField] private float barSpeed;
        [SerializeField] private Image frontBar;
        [SerializeField] private Image backBar;


        private void Start() => _currentHealthBar = maxHealthBar;

        public void Update()
        {
            _currentHealthBar = Mathf.Clamp(_currentHealthBar, 0, maxHealthBar);
            UpdateBar();
            if (_isTakingDamage) {
                TakeDamageBar(_damageAmount);
            }
        }

        public void UpdateBar()
        {
            float fillF = frontBar.fillAmount;
            float fillB = backBar.fillAmount;
            float hFraction = _currentHealthBar / maxHealthBar;
            //Aggiornamento quando la barra posteriore è maggiore della salute corrente
            if (fillB > hFraction) {
                frontBar.fillAmount = hFraction;
                backBar.color = Color.red;
                _lerpTimer += Time.deltaTime;
                float percentComplete = _lerpTimer / barSpeed;
                percentComplete = percentComplete * percentComplete;
                backBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
            }

            //Aggiornamento quando la barra posteriore è minore della salute corrente
            if (fillB < hFraction) {
                backBar.color = Color.green;
                backBar.fillAmount = hFraction;
                _lerpTimer += Time.deltaTime;
                float percentComplete = _lerpTimer / barSpeed;
                percentComplete = percentComplete * percentComplete;
                frontBar.fillAmount = Mathf.Lerp(fillF, backBar.fillAmount, percentComplete);
            }
            //healhText.text = health + "/" + maxHealth;
        }

        public void TakeDamageBar(int damage)
        {
            damage = _damageAmount;
            _currentHealthBar -= damage;
            Debug.Log("your current life is " + _currentHealthBar);
            _lerpTimer = 0f;
            _isTakingDamage = true;
        }

        public void ResetHealthBar(int healAmount)
        {
            _currentHealthBar += healAmount;
            _lerpTimer = 0f;
        }
    }
}
