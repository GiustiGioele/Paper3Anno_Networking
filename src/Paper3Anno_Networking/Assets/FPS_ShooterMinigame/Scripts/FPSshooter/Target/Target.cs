using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPShooter
{
    public abstract class Target : MonoBehaviour
    {
        [SerializeField] protected int targetHealth;

        public abstract void TargetTakeDamage(int amount);
        public abstract void TargetDie();
    }
}

