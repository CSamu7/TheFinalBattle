namespace TheFinalBattle.Attacks
{
    public class QuickShot : IAttack
    {
        public string Name { get; } = "Quick Shot";
        public DamageType DamageType { get; } = DamageType.Range;
        public AttackData CalculateAttack()
        {
            return new AttackData(3, DamageType, .5);
        }
    }
}
