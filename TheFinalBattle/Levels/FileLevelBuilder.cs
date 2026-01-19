using TheFinalBattle.Generators;
using TheFinalBattle.Levels.DTO;
using TheFinalBattle.Levels.Parser;
using TheFinalBattle.UI;

namespace TheFinalBattle.Levels
{
    public class FileLevelBuilder : ILevelBuilder
    {
        private readonly string _pathname;
        private readonly LevelsMapper _levelFormatter = new();
        private readonly JsonReader _reader = new();
        public FileLevelBuilder(string pathname)
        {
            _pathname = Path.Combine(Directory.GetCurrentDirectory(), pathname);
        }
        public List<Level> GetLevels()
        {
            List<LevelDTO> parsedLevels = _reader.Read(_pathname);
            List<Level> validLevels = _levelFormatter.MapLevels(parsedLevels);

            FileValidationUI validation = new(_levelFormatter.ErrorsPerLevel);
            validation.Display();

            return validLevels;
        }
    }
}
