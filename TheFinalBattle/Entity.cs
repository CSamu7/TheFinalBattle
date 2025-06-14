namespace TheFinalBattle
{
    public abstract class Entity
    {
        public string Name { get; init; }
        public int MaxHP { get; init; }
        public int HP { get; set; }
        public IAttack StandardAttack { get; protected set; }
    }
}
