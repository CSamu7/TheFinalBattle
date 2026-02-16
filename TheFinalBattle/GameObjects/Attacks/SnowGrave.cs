namespace TheFinalBattle.GameObjects.Attacks
{
    public class SnowGrave : Attack
    {
        private static Random _random = new Random();
        public override string Name => "SnowGrave";
        public override DamageType DamageType => DamageType.Ice;
        public override AttackData CalculateAttack()
        {
            int damage = _random.Next(2, 4);

            return new AttackData(damage, DamageType);
        }
    }
}
