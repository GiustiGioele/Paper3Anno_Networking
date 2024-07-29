using System;
using UnityEngine;
using UnityEngine.AI;

namespace FPShooter
{
    public class Enemy : MonoBehaviour
    {
        private StateMachine _stateMachine;
        private NavMeshAgent _agent;
        public NavMeshAgent Agent { get => _agent; }
        [SerializeField] private string currentState;
        public Path path;
        private void Start()
        {
            _stateMachine = GetComponent<StateMachine>();
            _agent = GetComponent<NavMeshAgent>();
            _stateMachine.Initialise();
        }
    }
}
