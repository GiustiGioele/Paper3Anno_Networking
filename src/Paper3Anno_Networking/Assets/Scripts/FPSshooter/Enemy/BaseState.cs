
namespace FPShooter
{
    public abstract class BaseState
    {
        public Enemy _enemy;
        public StateMachine _stateMachine;
        public abstract void Enter();
        public abstract void Perform();
        public abstract void Exit();
    }
}

