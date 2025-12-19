using TheFinalBattle.Generators;
using TheFinalBattle.Interface;

namespace TheFinalBattle
{
    public class Battles
    {
        public int battleNumber { get; private set; } = 1;
        private readonly List<Level> _levels;
        private Level? _level;
        public Battles(List<Level> levels)
        {
            _levels = levels;
        }
        public void Start(Party heroes, Party enemies)
        {
            while (heroes.Members.Count > 0)
            {
                if (_levels.ElementAtOrDefault(battleNumber) is null)
                {
                    BattleResults.DisplayGameOver();
                    return;
                }

                Battle battle = new Battle(heroes, enemies);
                battle.Start();

                FinishBattle(battle);
            }
        }
        public void FinishBattle(Battle battle)
        {
            var results = new BattleResults(battle);
            results.DisplayResults();

            Inventory enemyInventory = battle.Enemies.Inventory;
            Inventory heroesInventory = battle.Heroes.Inventory;

            enemyInventory.TransferInventory(heroesInventory);

            foreach(SlotInventory slot in _level.Rewards)
            {
                battle.Heroes.Inventory.AddItem(slot.Item, slot.Amount);
            }

            battleNumber++;
        }
    }
}
