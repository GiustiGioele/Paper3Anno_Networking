using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace FPShooter
{
    public abstract class Interactable : MonoBehaviour
    {
        public string promptMessage;
        public int interactableDamage;
        public void BaseInteract()
        {
            Interact();
        }
        protected virtual void Interact()
        {

        }

        public void InvokeDamage()
        {
            Debug.Log($"Invoking damage: {interactableDamage}");
            EventBus.Publish(new PlayerTakesDamageEvent(interactableDamage));
        }

    }
}

