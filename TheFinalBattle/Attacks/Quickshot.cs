namespace TheFinalBattle.Attacks
{
    public class QuickShot : IAttack
    {
        public string Name => "Quickshot";
        public DamageType DamageType => DamageType.Range;

        public AttackData CalculateAttack()
        {
            return new AttackData(3, DamageType, .55);
        }
    }
}
