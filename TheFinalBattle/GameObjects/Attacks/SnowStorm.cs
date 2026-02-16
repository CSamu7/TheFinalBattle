namespace TheFinalBattle.GameObjects.Attacks
{
    public class SnowStorm : IAttack
    {
        public string Name { get; } = "SnowStorm";
        public DamageType DamageType { get; } = DamageType.Ice;
        public AttackData CalculateAttack()
        {
            return new AttackData(3, DamageType, .70);
        }
    }
}
