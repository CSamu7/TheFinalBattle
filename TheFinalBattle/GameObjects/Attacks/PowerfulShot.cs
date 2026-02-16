namespace TheFinalBattle.GameObjects.Attacks
{
    public class PowerfulShot : Attack
    {
        public override string Name => "Powerful Shot";
        public override DamageType DamageType => DamageType.Range;
        public override AttackData CalculateAttack() => new AttackData(4, DamageType, .55);
    }
}
