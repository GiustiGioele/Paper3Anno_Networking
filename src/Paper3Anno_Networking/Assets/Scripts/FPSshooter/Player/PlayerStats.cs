using System;
using FPSshooter;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FPShooter
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private int maxHealth;
         public int currentHealth;


        private void Start()
        {
            // Interactable interactable = FindObjectOfType<Interactable>();
            // if (interactable != null) {
            //     interactable.OnDamage += TakeDamage;
            //     Debug.Log(" PlayerStats is subscribed to OnDamage");
            // }
            currentHealth = maxHealth;
        }

        // private void OnEnable()
        // {
        //     EventBus.Subscribe<PlayerTakesDamageEvent>(TakeDamage);
        // }
        //
        // private void OnDisable()
        // {
        //     EventBus.Unsubscribe<PlayerTakesDamageEvent>(TakeDamage);
        // }


        public void TakeDamage(PlayerTakesDamageEvent e)
        {
            currentHealth -= e._damageAmount;
            Debug.Log($"Player took {e._damageAmount} damage, current health is :" + currentHealth);
            if (currentHealth <= 0) {
                currentHealth = 0;
                PlayerDie();
            }
        }
        public void ResetHealth(int heal) => currentHealth += heal;

        // //private void PlayerDie()
        // {
        //     //Debug.Log("Player died")
        //     //EventBus.Publish(new PlayerDeathEvent);
        // }

        public void PlayerDie()
        {
            Debug.Log("Player Died");
            SceneManager.LoadScene("GameOver");

        }
    }
}
