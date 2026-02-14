using TheFinalBattle.Levels.DTO;
using TheFinalBattle.Levels.Mappers;
using TheFinalBattle.Parties;
using TheFinalBattle.UI;

namespace TheFinalBattle.Tests.Mappers
{
    public class MapperListTests
    {
        [Fact]
        public void Return_only_valid_items()
        {
            MapperList mapperList = new MapperList();
            ItemAmountMapper mapper = new ItemAmountMapper();
            List<ItemAmountDTO> items = new List<ItemAmountDTO>() {
                Helper.GetValidItemAmountDTO(3),
                Helper.GetInvalidItemAmountDTO(1)
            };

            (List<ItemAmount> validItems, List<MappingAlert> alerts) = mapperList.MapItems(items, mapper);

            Assert.Single(validItems);
            Assert.Single(alerts);
        }
    }
}
