using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteractable : Interactable
{
    public GameObject cube;
    public override void Interact()
    {
        Debug.Log("interacted with :" + gameObject.name);
        var cubePosition = cube.transform.position;
        cube.transform.position = new Vector3(cubePosition.x, (float)(cubePosition.y + 0.5),
            cubePosition.z);
        if (cubePosition.y >= 1 ) {
            Collider collider = GetComponent<Collider>();
            collider.enabled = false;
        }
    }
}
