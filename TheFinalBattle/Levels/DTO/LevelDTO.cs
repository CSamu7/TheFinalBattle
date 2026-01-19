namespace TheFinalBattle.Levels.DTO
{
    public class PartyDTO
    {
        public required List<ItemAmountDTO> Inventory { get; set; }
        public required List<EntityDTO> Enemies { get; set; }
    }
    public class LevelDTO
    {
        public required PartyDTO PartyEnemy { get; init; }
        public required List<ItemAmountDTO> Rewards { get; init; } = [];
    }
}