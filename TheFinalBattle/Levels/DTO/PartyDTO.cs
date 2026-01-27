namespace TheFinalBattle.Levels.DTO
{
    public class PartyDTO
    {
        public required List<ItemAmountDTO> Inventory { get; set; }
        public required List<EntityDTO> Enemies { get; set; }
    }
}
