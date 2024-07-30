using System;
using System.Collections;
using System.Collections.Generic;
using FPShooter;
using UnityEngine;

namespace FPShooter
{
    public class CubeInteractable : Interactable
    {
        protected override void Interact()
        {
            Debug.Log("interacted with : " + promptMessage);
            Destroy(this);
        }
    }
}

