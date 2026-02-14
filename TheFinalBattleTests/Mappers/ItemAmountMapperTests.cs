using TheFinalBattle.Levels.DTO;
using TheFinalBattle.Levels.Mappers;
using TheFinalBattle.Parties;

namespace TheFinalBattle.Tests.Mappers
{
    public class ItemAmountMapperTests
    {
        [Fact]
        public void Item_is_mapped_if_id_is_valid()
        {
            int amount = 4;
            ItemAmountDTO itemAmountDto = Helper.GetValidItemAmountDTO(amount);
            ItemAmountMapper mapper = new ItemAmountMapper();

            MappingResult<ItemAmount> result = mapper.Map(itemAmountDto);

            Assert.True(result.IsValid);
            Assert.True(result.Result.Amount == amount);
            Assert.True(result.Alerts.Count == 0);
        }
        [Fact]
        public void Item_is_not_mapped_if_id_is_invalid()
        {
            ItemAmountDTO itemAmountDto = Helper.GetInvalidItemAmountDTO(4);
            ItemAmountMapper mapper = new ItemAmountMapper();

            MappingResult<ItemAmount> result = mapper.Map(itemAmountDto);

            Assert.False(result.IsValid);
            Assert.True(result.Alerts.Count > 0);
            Assert.Throws<InvalidOperationException>(() => result.Result);
        }
    }
}
