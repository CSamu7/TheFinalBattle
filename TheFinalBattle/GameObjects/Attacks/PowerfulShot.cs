namespace TheFinalBattle.GameObjects.Attacks
{
    public class PowerfulShot : IAttack
    {
        public string Name => "Powerful Shot";
        public DamageType DamageType => DamageType.Range;
        public AttackData CalculateAttack() => new AttackData(4, DamageType, .55);
    }
}
