namespace TheFinalBattle.PlayerCommands.Attacks
{
    public class AssaulDive : IAttack
    {
        public string Name { get; } = "Assault Dive";
        public DamageType DamageType { get; } = DamageType.Physical;
        public AttackData CalculateAttack()
        {
            int rndDamage = new Random().Next(2, 4);

            return new AttackData(rndDamage, DamageType);
        }
    }
}
