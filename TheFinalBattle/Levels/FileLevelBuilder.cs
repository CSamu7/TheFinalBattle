using TheFinalBattle.Generators;
using System.Text.Json;
using TheFinalBattle.DTO;

namespace TheFinalBattle.Levels
{
    public class FileLevelBuilder : ILevelBuilder
    {
        private List<Level> _levels = new List<Level>();
        public FileLevelBuilder(string pathname)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), pathname);
            ReadFile(path);
        }
        private void ReadFile(string pathname)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };
            using FileStream openStream = File.OpenRead(pathname);
            List<LevelDTO> levels = JsonSerializer.Deserialize<List<LevelDTO>>(openStream, options);
            BuildLevels(levels);
        }
        private void BuildLevels(List<LevelDTO> levels)
        {
            foreach (LevelDTO levelJSON in levels)
            {
                Level level = levelJSON.Parse();
                _levels.Add(level);
            }
        }
        public Level GetLevel(Battles battles)
        {
            if(_levels.Count() >= battles.battleNumber)
                return _levels.ElementAt(battles.battleNumber - 1);

            return new Level([], new Inventory(), []);
        }
    }
}
