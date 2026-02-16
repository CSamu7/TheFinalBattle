using TheFinalBattle.GameObjects.Entities;
using TheFinalBattle.Levels.DTO;
using TheFinalBattle.Levels.Mappers;
using TheFinalBattle.Tests.Mappers.Helpers;

namespace TheFinalBattle.Tests.Mappers
{
    public class EntityMapperTests
    {
        [Fact]
        public void Entity_is_not_mapped_if_id_is_invalid()
        {
            EntityDTO entityJson = Helper.GetInvalidEntityDTO();
            EntityMapper mapper = new EntityMapper();

            MappingResult<Entity> result = mapper.Map(entityJson);

            Assert.False(result.IsValid);
            Assert.Throws<InvalidOperationException>(() => result.Result);
        }
        [Fact]
        public void Entity_is_mapped_if_id_is_valid()
        {
            EntityDTO entityJson = Helper.GetValidEntityDTO(null, null);
            EntityMapper mapper = new EntityMapper();

            MappingResult<Entity> result = mapper.Map(entityJson);

            Assert.True(result.IsValid);
            Assert.True(result.Alerts.Count == 0);
        }
        [Fact]
        public void Write_alerts_if_gear_or_defensive_modifier_are_invalid()
        {
            EntityDTO entityJson = Helper.GetValidEntityDTO(1967, 4325);
            EntityMapper mapper = new EntityMapper();

            MappingResult<Entity> result = mapper.Map(entityJson);

            Assert.True(result.IsValid);
            Assert.True(result.Alerts.Count == 2);
        }
    }
}
