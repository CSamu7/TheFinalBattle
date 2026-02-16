namespace TheFinalBattle.GameObjects.Attacks
{
    public class Pointer : IAttack
    {
        public string Name { get; } = "Zio";
        public DamageType DamageType { get; } = DamageType.Decoding;
        public AttackData CalculateAttack()
        {
            return new AttackData(3, DamageType, .70);
        }
    }
}
