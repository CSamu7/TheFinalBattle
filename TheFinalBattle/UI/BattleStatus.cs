using TheFinalBattle.GameObjects.Entities;
using TheFinalBattle.Parties;
using Utils;

namespace TheFinalBattle.UI
{
    public class BattleStatus
    {
        private readonly int _borderLength = 91;
        private readonly char _symbolBorder = '=';
        private readonly char _innerSymbolBorder = '-';

        private readonly string _tabs;
        private readonly string _innerBorder;
        public BattleStatus()
        {
            _innerBorder = "".PadRight(_borderLength, _innerSymbolBorder);
            _tabs = "".PadRight(8, '\t');
        }
        public void Display(Entity entity, Battle battle)
        {
            Party heroes = battle.GetPartyFor(entity);
            Party enemies = battle.GetEnemyPartyFor(entity);

            Thread.Sleep(1500);
            Console.Clear();

            DisplayTitle();

            Console.WriteLine(_innerBorder);
            DisplayActualParty(entity, heroes);
            Console.WriteLine(_innerBorder);
            DisplayEnemyParty(enemies);
            Console.WriteLine(_innerBorder);

            Thread.Sleep(800);
            Console.WriteLine($"It is {entity} turn...");
        }
        private void DisplayTitle()
        {
            int margin = _borderLength / 2 - 6;
            string outerBorder = "".PadRight(margin, _symbolBorder);

            Console.Write(outerBorder);
            Console.Write("BATTLE STATUS");
            Console.WriteLine(outerBorder);
        }
        private void DisplayActualParty(Entity actualEntity, Party party)
        {
            ConsoleUtils.WriteLine("PARTY", ConsoleColor.Green);

            foreach (Entity entity in party.Members)
            {
                ConsoleColor entityActiveColor = actualEntity == entity ? ConsoleColor.Yellow : ConsoleColor.White;
                ConsoleUtils.WriteLine($"* {entity} ({entity.HP}/{entity.MaxHP})", entityActiveColor);
                if (entity.Gear is not null)
                {
                    Console.WriteLine($"  - {entity.Gear}");
                }
            }
        }
        private void DisplayEnemyParty(Party party)
        {
            ConsoleUtils.WriteLine($"{_tabs}ENEMIES", ConsoleColor.Red);

            foreach (Entity entity in party.Members)
            {
                Console.WriteLine($"{_tabs}* {entity} ({entity.HP}/{entity.MaxHP})");
                if (entity.Gear is not null)
                {
                    Console.WriteLine($"{_tabs}  - {entity.Gear}");
                }
            }
        }
    }
}
