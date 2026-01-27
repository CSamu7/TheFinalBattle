using TheFinalBattle.Levels.DTO;
using TheFinalBattle.UI;

namespace TheFinalBattle.Levels.Mappers
{
    public record LevelsResult(int LevelsChecked, List<Level> Levels, List<List<MappingAlert>> Alerts);
    public class LevelsMapper()
    {
        private readonly LevelMapper _levelMapper = new();
        public List<List<MappingAlert>> Alerts { get; set; } = [];
        public int LevelsChecked { get; private set; }
        public int LevelsValid { get; private set; }
        public LevelsResult MapLevels(List<LevelDTO> jsonLevels)
        {
            List<Level> levels = [];

            foreach (LevelDTO jsonLevel in jsonLevels)
            {
                MappingResult<Level> level = _levelMapper.Map(jsonLevel);
                Alerts.Add(level.Alerts);

                if(level.IsValid)
                    levels.Add(level.Result);
            }

            return new LevelsResult(jsonLevels.Count, levels, Alerts);
        }
    }
    public enum AlertType { Info, Warn, Error }
}
