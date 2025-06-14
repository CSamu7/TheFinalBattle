using Utils;

namespace TheFinalBattle
{
    public class BattleStatus
    {
        private readonly int _maxLength = 77;
        public void Display(Entity entity, Battle battle)
        {
            Party heroes = battle.GetPartyFor(entity);
            Party enemies = battle.GetEnemyPartyFor(entity);

            Thread.Sleep(1500);
            Console.Clear();

            DisplayTitle();
            Console.WriteLine("".PadRight(_maxLength, '='));

            DisplayActualParty(entity, heroes);
            Console.WriteLine("".PadRight(_maxLength, '-'));
            DisplayEnemyParty(enemies);
            Console.WriteLine("".PadRight(_maxLength, '='));

            Thread.Sleep(800);
        }
        private void DisplayTitle()
        {
            Console.Write("".PadRight(32, '='));
            Console.Write("BATTLE STATUS");
            Console.WriteLine("".PadRight(32, '='));
        }
        private void DisplayActualParty(Entity actualEntity, Party heroes)
        {
            ConsoleUtils.WriteLine("PARTY", ConsoleColor.Green);

            foreach (Entity entity in heroes.Members)
            {
                if (actualEntity == entity)
                {
                    ConsoleUtils.WriteLine($"* {entity.Name} ({entity.HP}/{entity.MaxHP})", ConsoleColor.Yellow);
                } else
                {
                    Console.WriteLine($"* {entity.Name} ({entity.HP}/{entity.MaxHP})");
                }
            }
        }
        private void DisplayEnemyParty(Party enemies)
        {
            ConsoleUtils.WriteLine("\t\t\t\t\t\t\tPARTY ENEMY", ConsoleColor.Red);

            foreach (Entity enemy in enemies.Members)
            {
                Console.WriteLine($"\t\t\t\t\t\t\t* {enemy.Name} ({enemy.HP}/{enemy.MaxHP})");
            }
        }
    }
}
