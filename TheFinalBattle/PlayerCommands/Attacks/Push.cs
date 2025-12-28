namespace TheFinalBattle.PlayerCommands.Attacks
{
    public class Push : IAttack
    {
        public string Name { get; } = "Push";
        public DamageType DamageType { get; } = DamageType.Range;
        public AttackData CalculateAttack()
        {
            return new AttackData(2, DamageType, .7);
        }
    }
}
