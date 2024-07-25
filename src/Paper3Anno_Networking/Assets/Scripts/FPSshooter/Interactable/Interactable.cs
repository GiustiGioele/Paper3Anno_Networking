using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Interactable : MonoBehaviour
{
     public string prompt;

     public void BaseInteract()
     {
         Interact();
     }
    public abstract void Interact();
}
