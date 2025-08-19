namespace TheFinalBattle.Attacks
{
    public class QuickShot : IAttack
    {
        public string Name { get; } = "QuickShot";
        public override string ToString()
        {
            return "Quick shot";
        }
        public AttackData CalculateAttack()
        {
            return new AttackData(3, .5);
        }
    }
}
