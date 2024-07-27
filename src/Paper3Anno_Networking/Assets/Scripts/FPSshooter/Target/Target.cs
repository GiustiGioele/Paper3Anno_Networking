using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float targetHealth;

    public void TargetTakeDamage(float amount)
    {
        targetHealth -= amount;
        if (targetHealth <= 0) {
            TargetDie();
        }
    }

    public void TargetDie()
    {
        Destroy(gameObject);
    }
}
