namespace TheFinalBattle.Attacks
{
    public class Stab : IAttack
    {
        public string Name { get; } = "Stab";
        public DamageType DamageType {  get; } = DamageType.Physical;
        public AttackData CalculateAttack()
        {
            return new AttackData(1, DamageType);
        }
    }
}
