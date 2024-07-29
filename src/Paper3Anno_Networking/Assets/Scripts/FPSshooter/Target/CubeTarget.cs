using System.Collections;
using System.Collections.Generic;
using FPShooter;
using UnityEngine;

namespace FPShooter
{
    public class TargetCube : Target
    {
        public override void TargetTakeDamage(float amount)
        {
            TargetHealth -= amount;
            if (TargetHealth <= 0) {
                TargetDie();
            }
        }
        public override void TargetDie()
        {
            Destroy(gameObject);
        }
    }
}

