namespace TheFinalBattle.GameObjects.Attacks
{
    public class FireBite : Attack
    {
        private static Random _random = new Random();
        public override string Name => "Fire Bite";
        public override DamageType DamageType => DamageType.Fire;
        public override AttackData CalculateAttack()
        {
            int damage = _random.Next(2, 4);

            return new AttackData(damage, DamageType, .8);
        }
    }
}
