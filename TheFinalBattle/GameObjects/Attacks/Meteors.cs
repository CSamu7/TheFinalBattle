namespace TheFinalBattle.GameObjects.Attacks
{
    public class Meteors : Attack
    {
        public override string Name => "Meteors";
        public override DamageType DamageType => DamageType.Fire;
        public override AttackData CalculateAttack() => new AttackData(3, DamageType, .70);
    }
}
