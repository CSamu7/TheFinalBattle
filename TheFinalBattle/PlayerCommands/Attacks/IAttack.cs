namespace TheFinalBattle.PlayerCommands.Attacks
{
    //TODO: Otra propuesta para Abstract?
    public interface IAttack
    {
        public string Name { get; }
        public DamageType DamageType { get; }
        public AttackData CalculateAttack();
    }
    /// <param name="success">0 = Absolute Failure, 1 = Success</param>
    public enum DamageType { Physical, Decoding, Range, Mighty, Electric, Ice }
    public record AttackData(int DamagePoints, DamageType DamageType, double Success = 1 );
}
