namespace TheFinalBattle.Generators
{
    public record Level(
        Party Enemies,
        List<SlotInventory> Rewards
    );
    public interface ILevelBuilder
    {
        public List<Level> GetLevels();
    }
}
