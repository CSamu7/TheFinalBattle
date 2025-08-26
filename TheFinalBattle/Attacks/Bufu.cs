namespace TheFinalBattle.Attacks
{
    public class Bufu : IAttack
    {
        public string Name { get; } = "Bufu";
        public DamageType DamageType {  get; } = DamageType.Ice;
        public AttackData CalculateAttack()
        {
            return new AttackData(1, DamageType);
        }
    }
}
