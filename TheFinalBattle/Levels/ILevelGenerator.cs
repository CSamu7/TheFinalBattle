namespace TheFinalBattle.Levels
{
    public record Level(
        Party EnemyParty,
        List<ItemAmount> Rewards
    );
    public interface ILevelBuilder
    {
        public List<Level> GetLevels();
    }
}
