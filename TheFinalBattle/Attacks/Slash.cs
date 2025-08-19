namespace TheFinalBattle.Attacks
{
    public class Slash : IAttack
    {
        public string Name { get; } = "Slash";
        public AttackData CalculateAttack()
        {
            return new AttackData(2);
        }
    }
}
