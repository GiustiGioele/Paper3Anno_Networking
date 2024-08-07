namespace FPShooter
{
    public class PlayerTakesDamageEvent
    {
        public int _damageAmount;

        public PlayerTakesDamageEvent(int damageAmount)
        {
            _damageAmount = damageAmount;
        }
    }
}
