
namespace TheFinalBattle
{
    public class Battles
    {
        private PartyEnemyFactory _enemiesFactory;
        private int _levelNumber = 1;
        private Party _heroes;
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
                if (enemies is null) break;

                Console.Clear();
                
                Battle battle = new Battle(_heroes, enemies);
                battle.StartBattle();
                _levelNumber++;

                FinishBattle(enemies);
            }
        }
        public void FinishBattle(Party enemies)
        {
            BattleResults results = new BattleResults(_heroes, enemies);
            results.DisplayResults();

            foreach (KeyValuePair<Item, int> item in enemies.Inventory.Items)
            {
                enemies.Inventory.TransferItem(_heroes.Inventory, item.Key);
            }
        }
    }
}
