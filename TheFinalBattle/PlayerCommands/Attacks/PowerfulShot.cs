namespace TheFinalBattle.PlayerCommands.Attacks
{
    public class PowerfulShot : IAttack
    {
        public string Name => "Powerful Shot";
        public DamageType DamageType => DamageType.Range;
        AttackData IAttack.CalculateAttack()
        {
            return new AttackData(5, DamageType, .45);
        }
    }
}
