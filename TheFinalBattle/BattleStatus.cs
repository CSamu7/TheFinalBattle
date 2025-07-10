using Utils;

namespace TheFinalBattle
{
    public class BattleStatus
    {
        private readonly int _maxLength = 77;
        private readonly char _marginChar = '=';
        private readonly char _marginInsideChar = '-';
        public void Display(Entity entity, Battle battle)
        {
            Party heroes = battle.GetPartyFor(entity);
            Party enemies = battle.GetEnemyPartyFor(entity);

            Thread.Sleep(1500);
            Console.Clear();

            DisplayTitle();
            Console.WriteLine("".PadRight(_maxLength, _marginChar));
            ConsoleUtils.WriteLine("PARTY", ConsoleColor.Green);
            DisplayParty(entity, heroes);
            
            Console.WriteLine("".PadRight(_maxLength, _marginInsideChar));
            
            ConsoleUtils.WriteLine("\t\t\t\t\t\t\tENEMIES", ConsoleColor.Red);
            DisplayParty(entity, enemies,true);

            Console.WriteLine("".PadRight(_maxLength, _marginChar));

            Thread.Sleep(800);
        }
        private void DisplayTitle()
        {
            Console.Write("".PadRight(32, '='));
            Console.Write("BATTLE STATUS");
            Console.WriteLine("".PadRight(32, '='));
        }
        private void DisplayParty(Entity actualEntity, Party party, bool IsEnemyParty = false)
        {
            foreach (Entity entity in party.Members)
            {
                if (IsEnemyParty) Console.Write("\t\t\t\t\t\t\t");
                ConsoleColor color = actualEntity == entity ? ConsoleColor.Yellow : ConsoleColor.White;
                ConsoleUtils.WriteLine($"* {entity.Name} ({entity.HP}/{entity.MaxHP})", color);

                if (entity.Gear is not null)
                {
                    if (IsEnemyParty) Console.Write("\t\t\t\t\t\t\t");
                    Console.WriteLine($"  - {entity.Gear.Name}");
                }
            }
        }
    }
}
