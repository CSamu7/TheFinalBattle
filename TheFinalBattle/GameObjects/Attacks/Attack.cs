namespace TheFinalBattle.GameObjects.Attacks
{
    public abstract class Attack
    {
        public abstract string Name { get; }
        public abstract DamageType DamageType { get; }
        public abstract AttackData CalculateAttack();
    }
}
