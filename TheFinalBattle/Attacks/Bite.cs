namespace TheFinalBattle.Attacks
{
    public class Bite : IAttack
    {
        public string Name { get; } = "Bite";
        public AttackData CalculateAttack()
        {
            return new AttackData(2);
        }
    }
}
