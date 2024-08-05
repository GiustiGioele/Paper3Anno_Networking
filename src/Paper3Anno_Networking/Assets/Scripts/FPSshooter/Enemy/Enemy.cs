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
        public GameObject Player { get => _player; }
        [SerializeField] private string currentState;
        public Path path;
        private GameObject _player;
        [Header("Sight Values")]
        public float sightDistance;
        public float fieldOfView;
        public float eyeHeight;
        [Header("Weapon Values")]
        public Transform gunBarrel;
        public float speedOfBullet;
        [Range(0.1f, 10.0f)]
        public float fireRate;
        private void Start()
        {
            _stateMachine = GetComponent<StateMachine>();
            _agent = GetComponent<NavMeshAgent>();
            _stateMachine.Initialise();
            _player = GameObject.FindWithTag("Player");
        }

        private void Update()
        {
            CanSeePlayer();
            currentState = _stateMachine._activeState.ToString();
        }

        public bool CanSeePlayer()
        {
            if (_player != null) {
                if (Vector3.Distance(transform.position, _player.transform.position) < sightDistance) {
                    Vector3 targetDirection = _player.transform.position - transform.position - (Vector3.up * eyeHeight);
                    float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
                    if (angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView) {
                        Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), targetDirection);
                        RaycastHit hit = new RaycastHit();
                        if (Physics.Raycast(ray, out hit, sightDistance)) {
                            if (hit.transform.gameObject == _player) {
                                Debug.DrawRay(ray.origin, ray.direction * sightDistance, Color.red);
                                return true;
                            }
                        }

                    }
                }
            }

            return false;
        }

    }
}
