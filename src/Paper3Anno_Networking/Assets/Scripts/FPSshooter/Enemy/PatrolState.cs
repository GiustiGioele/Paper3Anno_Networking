using UnityEngine;

namespace FPShooter
{
    public class PatrolState : BaseState
    {
        public int _waypointsIndex;
        public float _waitTimer;
        public override void Enter() { }

        public override void Perform()
        {
            PatrolCycle();
        }
        public override void Exit() { }

        public void PatrolCycle()
        {
            if (_enemy.Agent.remainingDistance <= 0.1f && _enemy.Agent.velocity.sqrMagnitude <= 0.1f)
            {
                _waitTimer += Time.deltaTime;
                if (_waitTimer > 3)
                {
                    _waypointsIndex = (_waypointsIndex + 1) % _enemy.path.waypoints.Count;
                    _enemy.Agent.SetDestination(_enemy.path.waypoints[_waypointsIndex].position);
                    Debug.Log($"Current waypoints index : {_waypointsIndex}");
                    _waitTimer = 0;
                }
            }
            else
            {
                _waitTimer = 0;
            }

        }
    }
}
