using System;
using UnityEngine;

namespace FPShooter
{
    public class StateMachine : MonoBehaviour
    {
        //stato corrente dell'enemy
        public BaseState _activeState;

        public PatrolState _patrolState;
        public void Initialise()
        {
            _patrolState = new PatrolState();
            ChangeState(_patrolState);
        }
        private void Update()
        {
            if (_activeState != null) {
                _activeState.Perform();
            }
        }

        public void ChangeState(BaseState newState)
        {
            if (_activeState != null) {
                _activeState.Exit();
            }
            _activeState = newState;
            if (_activeState != null) {
                _activeState._stateMachine = this;
                _activeState._enemy = GetComponent<Enemy>();
                _activeState.Enter();
            }
        }
    }
}
