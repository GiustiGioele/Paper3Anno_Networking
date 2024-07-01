
using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Random = Unity.Mathematics.Random;


public class TagGame : NetworkBehaviour
{
    [SerializeField] private Material itMaterial;
    [SerializeField] private Material normalMaterial;

    private NetworkVariable<bool> _isIt = new NetworkVariable<bool>(false);
    private List<TagGame> _players = new List<TagGame>();

    private void Start()
    {
        _players.Add(this);
        if (IsServer) {
            if (_players.Count == NetworkManager.Singleton.ConnectedClients.Count) {
                AssignRandomPlayerAsIt();
            }
        }

        _isIt.OnValueChanged += (oldValue, newValue) => UpdateMaterial();
    }

    private void OnDestroy()
    {
        _players.Remove(this);
    }
    private void AssignRandomPlayerAsIt()
    {
        int randomIndex = Random.Range(0, _players.Count);
        _players[randomIndex]._isIt.Value = true;
        _players[randomIndex].UpdateMaterial();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsServer && _isIt.Value) {
            var otherPlayer = other.GetComponent<TagGame>();
            if (otherPlayer != null && !otherPlayer._isIt.Value) {
                _isIt.Value = false;
                otherPlayer._isIt.Value = true;
            }
        }
    }

    private void UpdateMaterial()
    {
        GetComponent<Renderer>().material = _isIt.Value ? itMaterial : normalMaterial;
    }


}
