using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Interactable : MonoBehaviour
{
     public string prompt;
     public event Action<float> OnDamage;
     public float interactableDamage;
     public void BaseInteract()
     {
         Interact();
         InvokeDamage();
     }
    public abstract void Interact();

    public void InvokeDamage()
    {
        OnDamage?.Invoke(interactableDamage);
    }

}
