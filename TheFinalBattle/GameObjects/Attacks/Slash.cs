namespace TheFinalBattle.GameObjects.Attacks
{
    public class Slash : Attack
    {
        public override string Name => "Slash";
        public override DamageType DamageType => DamageType.Physical;
        public override AttackData CalculateAttack() => new AttackData(2, DamageType);
    }
}
