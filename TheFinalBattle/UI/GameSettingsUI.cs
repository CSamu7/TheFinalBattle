using TheFinalBattle.Generators;
using TheFinalBattle.PartyControl;

namespace TheFinalBattle.UI
{
    public class GameSettingsUI
    {
        private LevelConfigUI levelConfig = new LevelConfigUI();
        private PartyControlUI partyConfig = new PartyControlUI();
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
