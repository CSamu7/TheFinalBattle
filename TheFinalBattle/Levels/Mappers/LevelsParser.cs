using TheFinalBattle.Generators;
using TheFinalBattle.Levels.DTO;
using TheFinalBattle.Levels.Mappers;
using TheFinalBattle.UI;

namespace TheFinalBattle.Levels.Parser
{
    public class LevelsMapper()
    {
        private readonly LevelMapper _levelMapper = new();
        public List<List<MappingAlert>> Alerts { get; set; } = [];
        public List<Level> MapLevels(List<LevelDTO> jsonLevels)
        {
            List<Level> levels = [];

            foreach (LevelDTO jsonLevel in jsonLevels)
            {
                MappingResult<Level> level = _levelMapper.Map(jsonLevel);
                Alerts.Add(level.Alerts);

                if(level.IsValid)
                    levels.Add(level.Result);
            }

            return levels;
        }
    }
    public enum AlertType { Info, Warn, Error }
}
