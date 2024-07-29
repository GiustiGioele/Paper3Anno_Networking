using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace FPShooter
{
    public class PlayerHealthBar : MonoBehaviour
{

    private float _lerpTimer;
    private float _currentHealth;
    [Header("Health Bar")]
    [SerializeField] private float maxHealth;
    [SerializeField] private  float barSpeed;
    [SerializeField] private Image frontBar;
    [SerializeField] private Image backBar;

    [Header("Damage Overlay")]
    public Image overlay;
    public float duration;
    public float fadeSpeed;
    private float _durationTimer;
    private Color _aplhaColor;

    private void Start()
    {
        _currentHealth = maxHealth;
        // overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0f);
        _aplhaColor = overlay.color;
    }

    public void Update()
    {
        _currentHealth = Mathf.Clamp(_currentHealth, 0, maxHealth);
        UpdateBar();
        float damage = 0;
        TakeDamage(damage);
        // ResetHealth(healAmount);
        // if (overlay.color.a > 0) {
        //     _durationTimer += Time.deltaTime;
        //     if (_durationTimer > duration) {
        //         //fade image
        //         float tempAlpha = overlay.color.a;
        //         tempAlpha -= Time.deltaTime * fadeSpeed;
        //         overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
        //     }
        // }
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
        //healhText.text = health + "/" + maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        Debug.Log("your current life is " + _currentHealth );
        _lerpTimer = 0f;
        if (_currentHealth < maxHealth) {
            _aplhaColor.a += .1f;
            overlay.color = _aplhaColor;
        }

        // _durationTimer = 0;
        // overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1f);
    }

    public void ResetHealth(float healAmount)
    {
        _currentHealth += healAmount;
        _lerpTimer = 0f;
    }
}
}

