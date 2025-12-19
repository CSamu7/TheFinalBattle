using System.Text.Json;
using TheFinalBattle.DTO;
using TheFinalBattle.Generators;
using TheFinalBattle.UI;

namespace TheFinalBattle.Levels
{
    public class FileLevelBuilder : ILevelBuilder
    {
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        };

        private readonly string _pathname;
        public FileLevelBuilder(string pathname)
        {
            _pathname = Path.Combine(Directory.GetCurrentDirectory(), pathname);
        }
        private List<LevelDTO> ParseFromStream()
        {
            using FileStream stream = File.OpenRead(_pathname);
            List<LevelDTO>? parsedLevels = JsonSerializer.Deserialize<List<LevelDTO>>(stream, _jsonOptions);

            if (parsedLevels is null)
                throw new JsonException("The JSON is not valid.");

            return parsedLevels;
        }
        public List<Level> GetLevels(LevelConfiguration levelConfiguration)
        {
            List<LevelDTO> parsedLevels = ParseFromStream();
            LevelFormatter levelFormatter = new LevelFormatter(levelConfiguration);
            FileValidationUI validation = new FileValidationUI();

            validation.Display();

            return parsedLevels;
        }
    }
}
