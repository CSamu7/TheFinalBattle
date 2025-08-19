namespace TheFinalBattle.Attacks
{
    public interface IAttack
    {
        public string Name { get; }
        AttackData CalculateAttack();
    }
    /// <param name="success">0 = Absolute Failure, 1 = Success</param>
    public record AttackData(int Damage, double Success = 1);
}
