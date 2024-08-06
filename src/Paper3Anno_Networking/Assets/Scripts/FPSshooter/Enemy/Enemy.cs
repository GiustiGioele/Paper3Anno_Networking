using System;
using FPSshooter;
using UnityEngine;
using UnityEngine.AI;

namespace FPShooter
{
    public class Enemy : MonoBehaviour
    {
        private StateMachine _stateMachine;
        private NavMeshAgent _agent;
        private Vector3 _lastKnowPos;
        public string enemyPromptMessage;
        [SerializeField] private int maxHealth;
        public int currentHealth;
        public bool enemyIsDead;
        public NavMeshAgent Agent { get => _agent; }
        public GameObject Player { get => _player; }
        public Vector3 LastKnowPos { get => _lastKnowPos; set => _lastKnowPos = value; }
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
            currentHealth = maxHealth;
            enemyIsDead = false;
            _stateMachine = GetComponent<StateMachine>();
            _agent = GetComponent<NavMeshAgent>();
            _stateMachine.Initialise();
            _player = GameObject.FindWithTag("Player");
        }

        private void OnEnable()
        {
            EventBus.Subscribe<EnemyTakesDamageEvent>(TakeDamage);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe<EnemyTakesDamageEvent>(TakeDamage);
        }

        private void Update()
        {
            CanSeePlayer();
            currentState = _stateMachine._activeState.ToString();
        }

        public bool CanSeePlayer()
        {
            if (_player != null && !enemyIsDead) {
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

        private void TakeDamage(EnemyTakesDamageEvent e)
        {
            currentHealth -= e._enemyDamageAmount;
            Debug.Log($"Enemy took {e._enemyDamageAmount} damage, current health is :" + currentHealth);
            if (currentHealth <= 0) {
                currentHealth = 0;
                //funzione di morte
                EnemyDie();
            }

        }

        private void EnemyDie()
        {
            enemyIsDead = true;
            Destroy(gameObject);
            Debug.Log("Enemy dead");
        }

    }
}
