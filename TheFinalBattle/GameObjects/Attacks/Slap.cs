namespace TheFinalBattle.GameObjects.Attacks
{
    public class Slap : Attack
    {
        public override string Name => "Slap";
        public override DamageType DamageType => DamageType.Physical;
        public override AttackData CalculateAttack() => new AttackData(1, DamageType);
    }
}
