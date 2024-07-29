using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPShooter
{
    public abstract class Target : MonoBehaviour
    {
        private float _targetHealth;
        protected float TargetHealth
        {
            get => _targetHealth;
            set => _targetHealth = value;
        }

        public abstract void TargetTakeDamage(float amount);
        public abstract void TargetDie();
    }
}

