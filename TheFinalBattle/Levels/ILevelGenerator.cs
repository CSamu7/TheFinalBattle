namespace TheFinalBattle.Generators
{
    public record Level(
        Party EnemyParty,
        List<SlotInventory> Rewards
    );
    public interface ILevelBuilder
    {
        public List<Level> GetLevels();
    }
}
