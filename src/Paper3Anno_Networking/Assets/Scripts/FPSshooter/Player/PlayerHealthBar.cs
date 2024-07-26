using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private  float barSpeed;
    [SerializeField] private Image frontBar;
    [SerializeField] private Image backBar;

    private float _currentHealth;
    private float _lerpTimer;
    private void Start()
    {
        _currentHealth = maxHealth;
    }

    private void Update()
    {
        _currentHealth = Mathf.Clamp(_currentHealth, 0, maxHealth);
        UpdateBar();
        if (Input.GetKeyDown(KeyCode.Q)) {
            TakeDamage(Random.Range(5,10));
            Debug.Log("take damage " + _currentHealth );
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            ResetHealth(Random.Range(5,10));
            Debug.Log("reset health " + _currentHealth );
        }
    }

    public void UpdateBar()
    {
        float fillF = frontBar.fillAmount;
        float fillB = backBar.fillAmount;
        float hFraction = _currentHealth / maxHealth;
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
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _lerpTimer = 0f;
    }

    public void ResetHealth(float healAmount)
    {
        _currentHealth += healAmount;
        _lerpTimer = 0f;
    }
}
