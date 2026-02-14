namespace TheFinalBattle.GameObjects.Attacks
{
    public class Zio : IAttack
    {
        public string Name { get; } = "Zio";
        public DamageType DamageType { get; } = DamageType.Electric;
        public AttackData CalculateAttack()
        {
            return new AttackData(1, DamageType);
        }
    }
}
