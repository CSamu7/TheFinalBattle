namespace TheFinalBattle.GameObjects.Attacks
{
    public class Megidolaon : IAttack
    {
        public string Name { get; } = "Megidolaon";
        public DamageType DamageType { get; } = DamageType.Mighty;
        public AttackData CalculateAttack()
        {
            Random rnd = new Random();
            int damage = rnd.Next(0, 4);
            return new AttackData(damage, DamageType);
        }
    }
}
