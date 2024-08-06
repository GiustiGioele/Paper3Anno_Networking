namespace FPSshooter
{
    public class EnemyTakesDamageEvent
    {
        public int _enemyDamageAmount;

        public EnemyTakesDamageEvent(int enemyDamageAmount)
        {
            _enemyDamageAmount = enemyDamageAmount;
        }
    }
}
