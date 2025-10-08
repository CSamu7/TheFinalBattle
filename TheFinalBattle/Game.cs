using TheFinalBattle.PlayableClasses.Heroes;
using TheFinalBattle.Items;
using TheFinalBattle.Generators;

namespace TheFinalBattle
{
    public class Game
    {
        public void Start()
        {
            ConfigParty configParty = new ConfigParty();

            Console.WriteLine("Configure the game: ");
            Party heroes = configParty.CreateParty("The player is controlled by (PC, Human): ");
            Party enemies = configParty.CreateParty("The monsters are controlled by (PC, Human): ");

            Console.Write("Enter your name, hero: ");
            string name = Console.ReadLine() ?? "Kiryu";

            Protagonist trueProgrammer = new Protagonist(name);
            heroes.AddMember(trueProgrammer);
            heroes.Inventory.AddItem(new Medicine(), 3);

            Battles battles = new Battles(enemies.PartyControl, new ScriptedLevelGenerator());
            battles.Start(heroes);
        }
    }
}
