namespace TheFinalBattle.GameObjects.Attacks
{
    public class CannonOfConsolas : Attack
    {
        private static Random _random = new Random();
        public override string Name => "Cannon Of Consolas";
        public override DamageType DamageType => DamageType.Decoding;
        public override AttackData CalculateAttack()
        {
            int rndNumber = _random.Next(1, 30);

            if (rndNumber % 5 == 0 && rndNumber % 3 == 0) return new AttackData(3, DamageType);
            if (rndNumber % 5 == 0 || rndNumber % 3 == 0) return new AttackData(2, DamageType);

            return new AttackData(1, DamageType, .75);
        }
    }
}
