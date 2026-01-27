namespace TheFinalBattle.Levels.DTO
{

    public class LevelDTO
    {
        public required PartyDTO PartyEnemy { get; init; }
        public required List<ItemAmountDTO> Rewards { get; init; } = [];
    }
}