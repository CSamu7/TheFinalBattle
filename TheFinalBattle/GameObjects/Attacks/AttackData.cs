namespace TheFinalBattle.GameObjects.Attacks
{
    public record AttackData
    {
        private double _success;
        private int _damagePoints;
        public int DamagePoints
        {
            get => _damagePoints;
            init
            {
                if (value < 0) _damagePoints = 0;
                _damagePoints = value;
            }
        }
        public DamageType DamageType { get; init; }
        public double Success
        {
            get => _success;
            set
            {
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
