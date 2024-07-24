using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime;
    public float speed;
    public Material hitMaterial;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("il proiettile ha colpito " + other.gameObject.name);
        if (other.CompareTag("Player")) {
            Renderer playerRenderer = other.GetComponent<Renderer>();
            if (playerRenderer != null && hitMaterial != null) {
                playerRenderer.material = hitMaterial;
            }
        }
    }
}
