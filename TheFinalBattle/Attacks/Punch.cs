namespace TheFinalBattle.Attacks
{
    public class Punch : IAttack
    {
        public string Name { get; } = "Punch";
        public AttackData CalculateAttack()
        {
            return new AttackData(1);
        }
    }
}
