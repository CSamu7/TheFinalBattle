using TheFinalBattle.Generators;
using TheFinalBattle.Levels;
using TheFinalBattle.PartyControl;
using TheFinalBattle.PlayableClasses;
using TheFinalBattle.PlayableClasses.Heroes;
using Utils;

namespace TheFinalBattle
{
    public class GameSettings(PartySettings partyConfiguration, List<Level> levels)
    {
        public PartySettings PartyConfiguration { get; set; } = partyConfiguration;
        public List<Level> Levels { get; } = levels;
    }
    public class PartySettings(IPartyControl heroePartyAI, IPartyControl enemyPartyAI)
    {
        public IPartyControl HeroePartyAI { get; set; } = heroePartyAI;
        public IPartyControl EnemyPartyAI { get; set; } = enemyPartyAI;
    }
    public class PlayerConfiguration()
    {
        public Entity GetPlayer()
        {
            Console.Write("Enter your name, hero: ");
            string name = Console.ReadLine() ?? "A hero with no name";

            return new Protagonist(name);
        }
    }
    public class PartyConfiguration()
    {
        public IPartyControl GetPartyAI(string message)
        {
            PartyControlValidator _partyValidator = new PartyControlValidator();

            while (true)
            {
                Console.Write(message);
                string inputAI = Console.ReadLine() ?? "";
                IPartyControl? ai = _partyValidator.Validate(inputAI);

                if (ai is not null) return ai;
            }
        }
    }
    public class LevelConfiguration
    {
        public List<Level> GetLevels()
        {
            ILevelBuilder? levelBuilder = null;

            while (true)
            {
                string input = ConsoleUtils.Input("Do you want to load your own levels? (y/n) ");

                if (input == "n")
                    levelBuilder = new ScriptLevelBuilder();

                if (input == "y")
                    levelBuilder = GetFileBuilder();

                if (levelBuilder is not null)
                    break;
            } 

            return levelBuilder.GetLevels();
        }

        private FileLevelBuilder GetFileBuilder()
        {
            while (true)
            {
                string pathname = ConsoleUtils.Input("Enter the pathname of the file: ");

                if (!File.Exists(pathname))
                {
                    ConsoleUtils.Error($"The file doesn't exist");
                    continue;
                }

                return new FileLevelBuilder(pathname);
            }
        }
    }
    public class ScreenConfiguration
    {
        LevelConfiguration levelConfig = new LevelConfiguration();
        PartyConfiguration partyConfig = new PartyConfiguration();
        public GameSettings GetSettings()
        {
            Console.WriteLine("Configuration of the game: ");
            IPartyControl heroesAI = partyConfig.GetPartyAI("The heroes are controlled by (PC, Human): ");
            IPartyControl enemiesAI = partyConfig.GetPartyAI("The monsters are controlled by (PC, Human): ");
            List<Level> levelBuilder = levelConfig.GetLevels();

            return new GameSettings(new(heroesAI, enemiesAI), levelBuilder);
        }
    }
}
