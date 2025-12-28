using TheFinalBattle.Generators;
using TheFinalBattle.Levels;
using Utils;

namespace TheFinalBattle.UI
{
    public class LevelConfigUI
    {
        public List<Level> GetLevelBuilder()
        {
            ILevelBuilder? levelBuilder = null;

            while (levelBuilder is null)
            {
                string input = ConsoleUtils.GetInput("Do you want to load your own levels? (y/n) ");

                if (input == "n")
                    levelBuilder = new ScriptLevelBuilder();

                if (input == "y")
                    levelBuilder = GetFileBuilder();
            }

            return levelBuilder.GetLevels();
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
