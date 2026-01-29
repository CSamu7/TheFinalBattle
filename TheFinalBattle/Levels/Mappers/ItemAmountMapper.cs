using TheFinalBattle.GameObjects.Items;
using TheFinalBattle.Levels.DTO;
using TheFinalBattle.UI;

namespace TheFinalBattle.Levels.Mappers
{
    public class ItemAmountMapper : IMapper<ItemAmountDTO, ItemAmount>
    {
        public MappingResult<ItemAmount> Map(ItemAmountDTO rawItem)
        {
            List<MappingAlert> Alerts = [];
            ItemList itemList = new();

            Item? item = itemList.GetByID(rawItem.Id);

            if (item is null)
            {
                Alerts.Add(new($"Item #{rawItem.Id} doesn't exist", AlertType.Warn));
                return MappingResult<ItemAmount>.Failure(Alerts);
            }
            
            return MappingResult<ItemAmount>.Success(new(item, rawItem.Amount), Alerts);
        }
    }
}
