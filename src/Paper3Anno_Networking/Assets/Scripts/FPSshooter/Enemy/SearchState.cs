using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPShooter
{
    public class SearchState : BaseState
    {
        private float _searchTimer;
        private float _moveTimer;

        public override void Enter()
        {
            _enemy.Agent.SetDestination(_enemy.LastKnowPos);
        }

        public override void Perform()
        {
            if (_enemy.CanSeePlayer()) {
                _stateMachine.ChangeState(new AttackState());
                if (_enemy.Agent.remainingDistance < _enemy.Agent.stoppingDistance) {
                    _searchTimer += Time.deltaTime;
                    _moveTimer += Time.deltaTime;
                    if (_moveTimer > Random.Range(3, 7)) {
                        _enemy.Agent.SetDestination(_enemy.transform.position + (Random.insideUnitSphere * 10));
                        _moveTimer = 0;
                    }
                    if (_searchTimer > 10) {
                        _stateMachine.ChangeState(new PatrolState());
                    }
                }
            }
        }

        public override void Exit()
        {

        }
}
}
