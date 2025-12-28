namespace TheFinalBattle.PlayerCommands.Attacks
{
    public class CannonOfConsolas : IAttack
    {
        public string Name => "Cannon Of Consolas";
        public DamageType DamageType => DamageType.Range;
        public AttackData CalculateAttack()
        {
            Random rnd = new Random();

            int rndNumber = rnd.Next(1, 30);

            if (rndNumber % 5 == 0 && rndNumber % 3 == 0) return new AttackData(3, DamageType);
            if (rndNumber % 5 == 0 || rndNumber % 3 == 0) return new AttackData(2, DamageType);

            return new AttackData(1, DamageType);
        }
    }
}
