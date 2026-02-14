using System.Text.Json;
using TheFinalBattle.Levels;
using Utils;

namespace TheFinalBattle.UI
{
    public class LevelsMenu
    {
        public List<Level> GetLevels()
        {
            while (true)
            {
                try
                {
                    ILevelBuilder levelBuilder = GetLevelBuilder();
                    List<Level> levels = levelBuilder.GetLevels();

                    if (levels.Count > 0)
                        return levels;
                } catch (JsonException error) //No me gusta aqui porque es muy especifico al FileLevelBuilder
                {
                    ConsoleUtils.Error(error.Message);
                }
            }
        }
        public ILevelBuilder GetLevelBuilder()
        {
            ILevelBuilder? levelBuilder = null;

            while (levelBuilder is null)
            {
                Console.Clear();
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
