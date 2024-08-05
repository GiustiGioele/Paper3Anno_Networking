using System.Collections;
using System.Collections.Generic;
using FPShooter;
using UnityEngine;

namespace FPShooter
{
    public class AttackState : BaseState
    {
        private float _moveTimer;
        private float _losePLayerTimer;
        private float _shotTimer;

        public override void Enter() { }

        public override void Perform()
        {
            if (_enemy.CanSeePlayer()) {
                _losePLayerTimer = 0;
                _moveTimer += Time.deltaTime;
                _shotTimer += Time.deltaTime;
                _enemy.transform.LookAt(_enemy.Player.transform);
                if (_shotTimer > _enemy.fireRate) {
                    Shoot();
                }

                if (_moveTimer > Random.Range(3, 7)) {
                    _enemy.Agent.SetDestination(_enemy.transform.position + (Random.insideUnitSphere * 5));
                    _moveTimer = 0;
                }
            }
            else {
                _losePLayerTimer += Time.deltaTime;
                if (_losePLayerTimer > 8) {
                    _stateMachine.ChangeState(new PatrolState());
                }
            }
        }

        public void Shoot()
        {
            Transform gunBarrel = _enemy.gunBarrel;
            GameObject bullet = GameObject.Instantiate(Resources.Load("Prefab/prefabsFPS/Bullet") as GameObject,gunBarrel.transform.position, _enemy.transform.rotation);
            Vector3 shootDirection = (_enemy.Player.transform.position - gunBarrel.transform.position).normalized;
            bullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-3f,3f), Vector3.up) * shootDirection * _enemy.speedOfBullet;
            Debug.Log("Shoot");
            _shotTimer = 0;
        }

        public override void Exit() => throw new System.NotImplementedException();
    }
}
