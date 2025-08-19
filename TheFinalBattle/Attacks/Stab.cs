namespace TheFinalBattle.Attacks
{
    public class Stab : IAttack
    {
        public string Name { get; } = "Stab";
        public AttackData CalculateAttack()
        {
            return new AttackData(1);
        }
    }
}
