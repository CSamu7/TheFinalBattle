using TheFinalBattle;

Console.ForegroundColor = ConsoleColor.White;
ConfigParty configParty = new ConfigParty();

Console.WriteLine("Configure the game: ");
Party heroes = configParty.CreateParty("The player is controlled by (PC, Human): ");
Party enemy = configParty.CreateParty("The monsters are controlled by (PC, Human): ");

heroes.AddItem(new HealthPotion(), 3);
enemy.AddItem(new HealthPotion(), 1);

Console.Write("Enter your name, hero: ");
string name = Console.ReadLine() ?? "Kiryu";

TrueProgrammer trueProgrammer = new TrueProgrammer(name);
heroes.AddMember(trueProgrammer);

Battles battles = new Battles(enemy);
battles.StartBattles(heroes);