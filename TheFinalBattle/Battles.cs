using TheFinalBattle.Generators;
using TheFinalBattle.Interface;
using TheFinalBattle.PartyControl;

namespace TheFinalBattle
{
    public class Battles
    {
        private ILevelGenerator _levelGenerator;
        public IPartyControl EnemyControl { get; init; }
        public int battleNumber { get; private set; } = 1;
        public Battles(IPartyControl enemyControl, ILevelGenerator levelGenerator)
        {
            _levelGenerator = levelGenerator;
            EnemyControl = enemyControl;
        }

        //¿Que pasa si ganan los enemigos? Parece que Heroes esta hardcodeado y no toma en cuenta realmente quien gano.
        public void Start(Party heroes)
        {
            while(heroes.Members.Count > 0)
            {
                Level level = _levelGenerator.GenerateLevel(this);
               
                if (level.Enemies.Members.Count <= 0)
                {
                    BattleResults.DisplayGameOver();
                    return;
                }

                Battle battle = new Battle(heroes, level.Enemies);
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
