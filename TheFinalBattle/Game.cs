using TheFinalBattle.GameObjects.Entities;
using TheFinalBattle.GameObjects.Entities.Heroes;
using TheFinalBattle.GameObjects.Items;
using TheFinalBattle.Parties;
using TheFinalBattle.UI;
using Utils;

namespace TheFinalBattle
{
    public class Game
    {
        public void Start()
        {
            var settings = new GameSettingsUI().GetSettings();

            string name = ConsoleUtils.GetInput("Enter your name, hero: ");
            name = name == String.Empty ? "A hero with no name" : name;

            Entity player = new Protagonist(name);

            Party heroes = new Party(settings.PartySettings.HeroePartyAI);
            heroes.Inventory.AddItem(new Medicine(), 3);
            heroes.AddMembers(player);

            Battles battles = new Battles(settings);
            battles.Start(heroes);
        }
    }
}
