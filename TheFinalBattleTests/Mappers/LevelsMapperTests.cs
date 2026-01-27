using TheFinalBattle.Levels.DTO;
using TheFinalBattle.Levels.Mappers;
using TheFinalBattle.UI;

namespace TheFinalBattle.Tests.Mappers
{
    public class LevelsMapperTests
    {
        [Fact]
        public void Get_only_valid_levels()
        {
            var mapper = new LevelsMapper();
            List<LevelDTO> levels = new List<LevelDTO>() {
                new LevelDTO {Rewards = [], PartyEnemy = Helper.GetPartyDTO(3,1)},
                new LevelDTO {Rewards = [], PartyEnemy = Helper.GetPartyDTO(1,0)}
            };

            LevelsResult result = mapper.MapLevels(levels);

            Assert.Single(result.Levels);
            Assert.Equal(2, result.LevelsChecked);
        }
    }
}
