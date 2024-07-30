using UnityEngine;

namespace FPShooter
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private int maxHealth;
        private int _currentHealth;
        private void Start() => maxHealth = _currentHealth;

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            Debug.Log("your current life is " + _currentHealth);
        }

        public void ResetHealth(int heal) => _currentHealth += heal;
    }
}
