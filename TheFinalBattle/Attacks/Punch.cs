namespace TheFinalBattle.Attacks
{
    public class Punch : IAttack
    {
        public string Name { get; } = "Punch";
        public DamageType DamageType { get; } = DamageType.Physical;
        public AttackData CalculateAttack()
        {
            return new AttackData(1, DamageType);
        }
    }
}
