namespace TheFinalBattle.GameObjects.Attacks
{
    public class Unraveling : Attack
    {
        private static Random _random = new Random();
        public override string Name => "Unraveling";
        public override DamageType DamageType => DamageType.Decoding;
        public override AttackData CalculateAttack()
        {
            int damage = _random.Next(3, 5);

            return new AttackData(damage, DamageType, .70);
        }
    }
}
