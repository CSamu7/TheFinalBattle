using TheFinalBattle.Items;
using TheFinalBattle.PlayableClasses;

namespace TheFinalBattle
{
    public class Game
    {
        public void Start()
        {
            var settings = new ScreenConfiguration().GetSettings();

            Entity player = new PlayerConfiguration().GetPlayer();

            Party heroes = new Party(settings.PartyConfiguration.HeroePartyAI);
            heroes.Inventory.AddItem(new Medicine(), 3);
            heroes.AddMembers(player);

            Party enemies = new Party(settings.PartyConfiguration.EnemyPartyAI);

            Battles battles = new Battles(settings.Levels);
            battles.Start(heroes, enemies);
        }
    }
}
