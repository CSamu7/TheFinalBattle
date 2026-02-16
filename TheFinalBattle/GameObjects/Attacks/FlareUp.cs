namespace TheFinalBattle.GameObjects.Attacks
{
    public class FlareUp : IAttack
    {
        public string Name { get; } = "Zionga";
        public DamageType DamageType { get; } = DamageType.Fire;
        public AttackData CalculateAttack()
        {
            return new AttackData(3, DamageType, .70);
        }
    }
}
