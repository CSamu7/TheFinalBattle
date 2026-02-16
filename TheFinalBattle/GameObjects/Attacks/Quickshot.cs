namespace TheFinalBattle.GameObjects.Attacks
{
    public class QuickShot : Attack
    {
        public override string Name => "Quickshot";
        public override DamageType DamageType => DamageType.Range;
        public override AttackData CalculateAttack() => new AttackData(3, DamageType, .50);
    }
}
