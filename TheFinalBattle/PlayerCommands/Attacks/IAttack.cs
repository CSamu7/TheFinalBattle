namespace TheFinalBattle.PlayerCommands.Attacks
{
    public interface IAttack
    {
        public string Name { get; }
        public DamageType DamageType { get; }
        public AttackData CalculateAttack();
    }
    /// <param name="success">0 = Absolute Failure, 1 = Success</param>
    public enum DamageType { Physical, Decoding, Range, Mighty, Electric, Ice }
    public record AttackData
    {
        private double _success;
        private int _damagePoints;
        public int DamagePoints { 
            get => _damagePoints; 
            init {
                if (value < 0) _damagePoints = 0;
                _damagePoints = value;
            } 
        }
        public DamageType DamageType { get; init; }
        public double Success 
        { 
            get => _success;
            set {
                if (value > 1) _success = 1;
                if (value < 0) _success = 0;
                _success = value;
            }
        }
        public AttackData(int damagePoints, DamageType damageType, double success = 1)
        {
            DamageType = damageType;
            Success = success;
            DamagePoints = damagePoints;
        }
    }
}
