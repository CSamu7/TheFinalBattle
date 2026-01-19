using System.Text.Json;
using TheFinalBattle.Levels.DTO;

namespace TheFinalBattle.Levels
{
    public class JsonReader : IFileReader<List<LevelDTO>>
    {
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        };
        public List<LevelDTO> Read(string path)
        {
            using FileStream stream = File.OpenRead(path);

            List<LevelDTO>? parsedLevels = JsonSerializer.Deserialize<List<LevelDTO>>(stream, _jsonOptions);

            if (parsedLevels is null)
                throw new JsonException("The JSON file is not valid.");

            return parsedLevels;
        }
    }
}
