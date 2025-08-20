namespace TheFinalBattle.Attacks
{
    public class Unraveling : IAttack
    {
        public string Name { get; } = "Unraveling";
        public DamageType DamageType { get; } = DamageType.Decoding;
        public AttackData CalculateAttack()
        {
            Random rnd = new Random();
            int damage = rnd.Next(0, 4);
            return new AttackData(damage, DamageType);
        }
    }
}
