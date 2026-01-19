using TheFinalBattle.Generators;
using TheFinalBattle.Items;
using TheFinalBattle.Levels.DTO;
using TheFinalBattle.UI;

namespace TheFinalBattle.Levels.Parser
{
    public class LevelsMapper()
    {
        private readonly LevelMapper _levelMapper = new();
        public List<List<MappingError>> ErrorsPerLevel { get; set; } = [];
        public List<Level> MapLevels(List<LevelDTO> jsonLevels)
        {
            List<Level> levels = [];

            foreach (LevelDTO jsonLevel in jsonLevels)
            {
                Level? level = _levelMapper.Map(jsonLevel);
                ErrorsPerLevel.Add(_levelMapper.Errors);

                if(level is not null)
                    levels.Add(level);
            }

            return levels;
        }
    }
    public enum ErrorType { Warn, Error }
}
