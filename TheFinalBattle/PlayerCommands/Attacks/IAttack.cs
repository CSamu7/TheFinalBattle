namespace TheFinalBattle.PlayerCommands.Attacks
{
    public interface IAttack
    {
        public string Name { get; }
        public DamageType DamageType { get; }
        AttackData CalculateAttack();
    }
    /// <param name="success">0 = Absolute Failure, 1 = Success</param>
    public enum DamageType { Physical, Decoding, Range, Mighty, Electric, Ice }
    public record AttackData(int Damage, DamageType DamageType, double Success = 1 );
}
