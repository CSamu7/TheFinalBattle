using TheFinalBattle.Levels.DTO;
using TheFinalBattle.Levels.Mappers;
using TheFinalBattle.UI;

namespace TheFinalBattle.Levels
{
    public class FileLevelBuilder : ILevelBuilder
    {
        private readonly string _pathname;
        private readonly LevelsMapper _levelMapper = new();
        private readonly JsonReader _reader = new();
        public FileLevelBuilder(string pathname)
        {
            _pathname = Path.Combine(Directory.GetCurrentDirectory(), pathname);
        }
        public List<Level> GetLevels()
        {
            List<LevelDTO> parsedLevels = _reader.Read(_pathname);
            LevelsResult mappingResult = _levelMapper.MapLevels(parsedLevels);

            FileValidationUI validationUI = new(mappingResult);
            validationUI.Display();

            bool confirmation = false;

            if (mappingResult.Levels.Count > 0)
                confirmation = DoesUserWantAdvance();

            return confirmation ? mappingResult.Levels : [];
        }
        private bool DoesUserWantAdvance()
        {
            Console.WriteLine("Do you want to continue? (y/n)");

            string confirmation = Console.ReadLine() ?? "";

            return confirmation == "y";
        }
    }
}
