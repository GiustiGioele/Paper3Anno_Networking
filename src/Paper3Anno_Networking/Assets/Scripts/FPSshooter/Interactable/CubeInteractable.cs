using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteractable : Interactable
{
    public override void Interact()
    {
        Debug.Log("interacted with :" + gameObject.name);

    }

}
