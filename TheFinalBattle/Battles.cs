
namespace TheFinalBattle
{
    public class Battles
    {
        private PartyEnemyFactory _enemiesFactory;
        private int _levelNumber = 1;
        private Party _heroes;
        private BattleResults _results;

        public Battles(Party heroes, Party enemies)
        {
            _enemiesFactory = new PartyEnemyFactory(enemies.PartyControl);
            _heroes = heroes;
        }
        public void Start()
        {
            while(_heroes.Length > 0)
            {
                Party? enemies = _enemiesFactory.Create(_levelNumber);
                if (enemies == null)
                {
                    BattleResults.DisplayGameOver();
                }

                Battle battle = new Battle(_heroes, enemies);
                battle.StartBattle();
                _levelNumber++;

                FinishBattle(battle);
            }
        }
        public void FinishBattle(Battle battle)
        {
            var results = new BattleResults(battle);
            results.DisplayResults();

            Inventory enemyInventory = battle.Enemies.Inventory;

            foreach (KeyValuePair<Item, int> item in enemyInventory.Items)
            {
                enemyInventory.TransferItem(_heroes.Inventory, item.Key);
            }
        }
    }
}
