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
    public class ItemAmountMapper : AbstractMapper<ItemAmountDTO, ItemAmount?>
    {
        public override List<MappingError> Errors { get; protected set; } = [];
        public override ItemAmount? Map(ItemAmountDTO rawItem)
        {
            Errors = [];
            ItemList itemList = new();

            Item? item = itemList.GetByID(rawItem.Id);

            if (item is null)
            {
                Errors.Add(new($"Item #{rawItem.Id} doesn't exist", ErrorType.Warn));
                return null; 
            } else
            {
                return new ItemAmount(item, rawItem.Amount);    
            }
        }
    }
}
