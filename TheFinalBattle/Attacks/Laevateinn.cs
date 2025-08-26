namespace TheFinalBattle.Attacks
{
    public class Laevateinn : IAttack
    {
        public string Name { get; } = "Punch";
        public DamageType DamageType { get; } = DamageType.Physical;
        public AttackData CalculateAttack()
        {
            int rndDamage = new Random().Next(4, 6);

            return new AttackData(rndDamage, DamageType);
        }
    }
}
