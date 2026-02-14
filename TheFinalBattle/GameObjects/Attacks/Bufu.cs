namespace TheFinalBattle.GameObjects.Attacks
{
    public class Bufu : IAttack
    {
        public string Name { get; } = "Bufu";
        public DamageType DamageType { get; } = DamageType.Ice;
        public AttackData CalculateAttack()
        {
            return new AttackData(10, DamageType);
        }
    }
}
