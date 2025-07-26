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

            heroes.Inventory.AddItem(new HealthPotion(), 3);
            heroes.Inventory.AddItem(new Dagger());

            Console.Write("Enter your name, hero: ");
            string name = Console.ReadLine() ?? "Kiryu";

            TrueProgrammer trueProgrammer = new TrueProgrammer(name);
            heroes.AddMember(trueProgrammer);

            Battles battles = new Battles(heroes, enemies);
            battles.Start();
        }
    }
}
