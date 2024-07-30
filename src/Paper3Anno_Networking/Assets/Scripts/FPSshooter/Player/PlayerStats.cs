using System;
using UnityEngine;

namespace FPShooter
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private int currentHealth;


        private void Start()
        {
            // Interactable interactable = FindObjectOfType<Interactable>();
            // if (interactable != null) {
            //     interactable.OnDamage += TakeDamage;
            //     Debug.Log(" PlayerStats is subscribed to OnDamage");
            // }
            currentHealth = maxHealth;
        }


        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            Debug.Log($"Player took {damage} damage, current health is :" + currentHealth);
        }


        public void ResetHealth(int heal) => currentHealth += heal;
    }
}
