namespace TheFinalBattle.Attacks
{
    public class Bite : IAttack
    {
        public string Name { get; } = "Bite";
        public DamageType DamageType { get; } = DamageType.Physical;
        public AttackData CalculateAttack()
        {
            return new AttackData(2, DamageType);
        }
    }
}
