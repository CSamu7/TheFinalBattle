using System.Text.Json;
using TheFinalBattle.Generators;
using TheFinalBattle.Levels;
using Utils;

namespace TheFinalBattle.UI
{
    public class LevelConfigUI
    {
        private LevelsFileMenu _fileMenuUI = new LevelsFileMenu();
        public List<Level> GetLevels()
        {
            List<Level> levels = new List<Level>();

            while (true)
            {
                try
                {
                    ILevelBuilder levelBuilder = GetLevelBuilder();
                    levels = levelBuilder.GetLevels();

                    if (levels.Count > 0)
                        return levels;
                } catch (JsonException error) //No me gusta aqui porque es muy especifico al FileLevelBuilder
                {
                    ConsoleUtils.Error(error.Message);
                    continue;
                }
            }
        }
        public ILevelBuilder GetLevelBuilder()
        {
            ILevelBuilder? levelBuilder = null;

            while (levelBuilder is null)
            {
                string input = ConsoleUtils.GetInput("Do you want to load your own levels? (y/n) ");

                levelBuilder = input switch
                {
                    "n" => new ScriptLevelBuilder(),
                    "y" => GetFileBuilder(),
                    _ => null
                };

                if (levelBuilder is null)
                    ConsoleUtils.Error("You have to enter an acceptable option (y/n)");
            }

            return levelBuilder;
        }
        private FileLevelBuilder GetFileBuilder()
        {
            while (true)
            {
                string pathname = ConsoleUtils.GetInput("Enter the pathname of the file: ");

                if (File.Exists(pathname))
                    return new FileLevelBuilder(pathname);

                ConsoleUtils.Error($"The file doesn't exist");
            }
        }
    }
}
