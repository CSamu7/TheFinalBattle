namespace TheFinalBattle.Attacks
{
    public class BoneCrunch : IAttack
    {
        public string Name { get; } = "Bone Crunch";
        public DamageType DamageType { get; } = DamageType.Physical;
        public AttackData CalculateAttack()
        {
            Random rnd = new Random();
            int damage = rnd.Next(0, 2);
            return new AttackData(damage, DamageType);
        }
    }
}
