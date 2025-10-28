using TheFinalBattle.Generators;
using TheFinalBattle.Levels;
using TheFinalBattle.PartyControl;
using Utils;

namespace TheFinalBattle
{
    public record GameConfiguration(
        IPartyControl HeroePartyAI, 
        IPartyControl EnemyPartyAI, 
        ILevelBuilder LevelConfiguration);
    public class ConfigurationScreen
    {
        public GameConfiguration CreateConfigGame()
        {
            Console.WriteLine("Configuration of the game: ");
            IPartyControl heroesAI = GetPartyAI("The heroes are controlled by (PC, Human): ");
            IPartyControl enemiesAI = GetPartyAI("The monsters are controlled by (PC, Human): ");
            ILevelBuilder levelBuilder = GetLevelBuilder();

            return new GameConfiguration(heroesAI, enemiesAI, levelBuilder);
        }
        private ILevelBuilder GetLevelBuilder()
        {
            while (true) {
                string input = ConsoleUtils.Input("Do you want to load your own levels? (y/n) ");

                if (input == "n") return new ScriptLevelBuilder();
                if (input == "") continue;

                try
                {
                    string pathname = ConsoleUtils.Input("Enter the pathname of the file: ");

                    if (!File.Exists(pathname))
                    {
                        ConsoleUtils.Error($"The file doesn't exist");
                        continue;
                    }

                    return new FileLevelBuilder(pathname);
                }   catch (Exception e)
                {
                    ConsoleUtils.Error("The serialization failed. Check if your levels.json is well formatted");
                }
            }
        }
        private IPartyControl GetPartyAI(string message)
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
}
