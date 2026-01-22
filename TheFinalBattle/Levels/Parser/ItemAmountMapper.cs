using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalBattle.Items;
using TheFinalBattle.Levels.DTO;
using TheFinalBattle.UI;

namespace TheFinalBattle.Levels.Parser
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
                Alerts.Add(new($"Item #{rawItem.Id} doesn't exist", ErrorType.Warn));
                return MappingResult<ItemAmount>.Failure(Alerts);
            }
            
            return MappingResult<ItemAmount>.Success(new(item, rawItem.Amount), Alerts);
        }
    }
}
