using TheFinalBattle.PlayableClasses.Heroes;
using TheFinalBattle.Items;

namespace TheFinalBattle
{
    public class Game
    {
        public void Start()
        {
            GameConfiguration gameConfiguration = new ConfigurationScreen().CreateConfigGame();

            Console.Write("Enter your name, hero: ");
            string name = Console.ReadLine() ?? "A hero with no name";

            Protagonist trueProgrammer = new Protagonist(name);

            Party heroes = new Party(gameConfiguration.HeroePartyAI);
            heroes.AddMember(trueProgrammer);
            heroes.Inventory.AddItem(new Medicine(), 3);

            Party enemies = new Party(gameConfiguration.EnemyPartyAI);
            Battles battles = new Battles(gameConfiguration.LevelConfiguration);
            battles.Start(heroes, enemies);
        }
    }
}
