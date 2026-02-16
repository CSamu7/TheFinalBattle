using TheFinalBattle.Levels;
using TheFinalBattle.Levels.DTO;
using TheFinalBattle.Levels.Mappers;
using TheFinalBattle.Tests.Mappers.Helpers;

namespace TheFinalBattle.Tests.Mappers
{
    public class LevelMapperTests
    {
        [Fact]
        public void Level_is_mapped_if_at_least_enemy_is_valid()
        {
            LevelMapper mapper = new LevelMapper();
            LevelDTO levelDto = new LevelDTO
            {
                Rewards = [], PartyEnemy = Helper.GetPartyDTO(2, 1)
            };

            MappingResult<Level> result = mapper.Map(levelDto);

            Assert.True(result.IsValid);
        }
        [Fact]
        public void Level_is_not_mapped_if_all_entities_are_invalid()
        {
            LevelMapper mapper = new LevelMapper();
            LevelDTO levelDto = new LevelDTO
            {
                Rewards = [],
                PartyEnemy = Helper.GetPartyDTO(2, 0)
            };

            MappingResult<Level> result = mapper.Map(levelDto);

            Assert.False(result.IsValid);
        }
    }
}
