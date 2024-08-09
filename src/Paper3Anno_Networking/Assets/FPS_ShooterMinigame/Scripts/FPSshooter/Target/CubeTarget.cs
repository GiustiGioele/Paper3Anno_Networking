using System.Collections;
using System.Collections.Generic;
using FPShooter;
using UnityEngine;

namespace FPShooter
{
    public class TargetCube : Target
    {
        public override void TargetTakeDamage(int amount)
        {
            targetHealth -= amount;
            if (targetHealth <= 0) {
                TargetDie();
            }
        }
        public override void TargetDie()
        {
            Destroy(gameObject);
        }
    }
}

