using TheFinalBattle.Items;

namespace TheFinalBattle.DTO
{
    public class SlotInventoryDTO
    {
        public required int Id { get; init; }
        public required int Amount { get; init; }
    }
    public static class SlotInventoryDTOExtensions
    {
        public static bool TryMap(this SlotInventoryDTO slotDTO, out SlotInventory? slot)
        {
            ItemList itemList = new ItemList();

            Item? item = itemList.GetByID(slotDTO.Id);

            if (item is null)
            {
                slot = null;
                return false;
            }

            slot = new SlotInventory(item, slotDTO.Amount);
            return true;
        }
    }
}
