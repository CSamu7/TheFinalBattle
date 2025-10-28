using TheFinalBattle.Generators;
using TheFinalBattle.Interface;
using TheFinalBattle.Items;

namespace TheFinalBattle
{
    public class Battles
    {
        private ILevelBuilder _levelGenerator;
        public int battleNumber { get; private set; } = 1;
        public Battles(ILevelBuilder levelGenerator)
        {
            _levelGenerator = levelGenerator;
        }

        public void Start(Party heroes, Party enemies)
        {
            while(heroes.Members.Count > 0)
            {
                Level level = _levelGenerator.GetLevel(this);

                if (level.Enemies.Count <= 0)
                {
                    BattleResults.DisplayGameOver();
                    return;
                }

                enemies.AddMembers(level.Enemies);
                level.EnemyInventory.TransferInventory(enemies.Inventory);

                Battle battle = new Battle(heroes, enemies);
                battle.StartBattle();

                FinishBattle(battle, level);
                battleNumber++;
            }
        }

        public void FinishBattle(Battle battle, Level level)
        {
            var results = new BattleResults(battle);
            results.DisplayResults();

            Inventory enemyInventory = battle.Enemies.Inventory;
            Inventory heroesInventory = battle.Heroes.Inventory;

            enemyInventory.TransferInventory(heroesInventory);

            foreach(SlotInventory slot in level.Rewards)
            {
                battle.Heroes.Inventory.AddItem(slot.Item, slot.Amount);
            }
        }
    }
}
