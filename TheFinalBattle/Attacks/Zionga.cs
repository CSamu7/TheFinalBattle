namespace TheFinalBattle.Attacks
{
    public class Zionga : IAttack
    {
        public string Name { get; } = "Zionga";
        public DamageType DamageType { get; } = DamageType.Electric;
        public AttackData CalculateAttack()
        {
            return new AttackData(3, DamageType);
        }
    }
}
