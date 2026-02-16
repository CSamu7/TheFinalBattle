namespace TheFinalBattle.GameObjects.Attacks
{
    public class Slap : IAttack
    {
        public string Name => "Slap";
        public DamageType DamageType => DamageType.Physical;
        public AttackData CalculateAttack()
        {
            return new AttackData(1, DamageType);
        }
    }
}
