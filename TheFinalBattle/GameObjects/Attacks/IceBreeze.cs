namespace TheFinalBattle.GameObjects.Attacks
{
    public class IceBreeze : Attack
    {
        public override string Name => "Ice Breeze";
        public override DamageType DamageType => DamageType.Fire;
        public override AttackData CalculateAttack() => new AttackData(2, DamageType, .85);
    }
}
