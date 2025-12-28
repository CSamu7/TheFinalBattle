namespace TheFinalBattle.PlayerCommands.Attacks
{
    public class Slash : IAttack
    {
        public string Name => "Slash";
        public DamageType DamageType => DamageType.Physical;
        public AttackData CalculateAttack()
        {
            return new AttackData(2, DamageType);
        }
    }
}
