namespace TheFinalBattle.PlayerCommands.Attacks
{
    public class BladedRunners : IAttack
    {
        public string Name => "Bladed Runners";
        public DamageType DamageType => DamageType.Physical;

        public AttackData CalculateAttack()
        {
            int rndNumber = new Random().Next(1, 4);

            return new AttackData(rndNumber, DamageType);
        }
    }
}
