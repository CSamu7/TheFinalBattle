using TheFinalBattle.Levels;
using TheFinalBattle.Parties;

namespace TheFinalBattle.UI
{
    public class GameSettingsUI
    {
        private LevelsMenu levelConfig = new LevelsMenu();
        private PartyControlUI partyConfig = new PartyControlUI();
        public GameSettings GetSettings()
        {
            Console.WriteLine("Configuration of the game: ");
            IPartyControl heroesAI = partyConfig.GetPartyAI("The heroes are controlled by (PC, Human): ");
            IPartyControl enemiesAI = partyConfig.GetPartyAI("The monsters are controlled by (PC, Human): ");

            List<Level> levels = levelConfig.GetLevels();
            return new GameSettings(new(heroesAI, enemiesAI), levels);
        }
    }
}
