namespace TheFinalBattle.GameObjects.Attacks
{
    public interface IAttack
    {
        public string Name { get; }
        public DamageType DamageType { get; }
        public AttackData CalculateAttack();
    }


}
