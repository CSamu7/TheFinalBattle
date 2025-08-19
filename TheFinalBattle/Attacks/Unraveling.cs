namespace TheFinalBattle.Attacks
{
    public class Unraveling : IAttack
    {
        public string Name { get; } = "Unraveling";
        public AttackData CalculateAttack()
        {
            Random rnd = new Random();
            int damage = rnd.Next(0, 3);
            return new AttackData(damage);
        }
    }
}
