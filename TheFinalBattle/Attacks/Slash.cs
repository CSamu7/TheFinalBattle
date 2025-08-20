namespace TheFinalBattle.Attacks
{
    public class Slash : IAttack
    {
        public string Name { get; } = "Slash";
        public DamageType DamageType { get; } = DamageType.Physical;
        public AttackData CalculateAttack()
        {
            return new AttackData(2, DamageType);
        }
    }
}
