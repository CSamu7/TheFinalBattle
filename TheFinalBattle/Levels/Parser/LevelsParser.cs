using TheFinalBattle.Generators;
using TheFinalBattle.Items;
using TheFinalBattle.Levels.DTO;
using TheFinalBattle.UI;

namespace TheFinalBattle.Levels.Parser
{
    public class LevelsMapper()
    {
        private readonly LevelMapper _levelMapper = new();
        public List<List<MappingAlert>> ErrorsPerLevel { get; set; } = [];
        public List<Level> MapLevels(List<LevelDTO> jsonLevels)
        {
            List<Level> levels = [];

            foreach (LevelDTO jsonLevel in jsonLevels)
            {
                MappingResult<Level?> level = _levelMapper.Map(jsonLevel);
                ErrorsPerLevel.Add(level.Errors);

                if(level.MappedObject is not null)
                    levels.Add(level.MappedObject);
            }

            return levels;
        }
    }
    public enum ErrorType { Warn, Error }
}
