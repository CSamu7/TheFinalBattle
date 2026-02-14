using TheFinalBattle.Levels;
using TheFinalBattle.Parties;
using TheFinalBattle.UI;

namespace TheFinalBattle
{
    public class Battles
    {
        private readonly List<Level> _levels;
        private readonly GameSettings _gameSettings;
        public Battles(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            _levels = gameSettings.Levels;
        }
        public void Start(Party heroes)
        {
            for (int i = 0; i < _levels.Count; i++)
            {
                _levels[i].EnemyParty.PartyControl = _gameSettings.PartySettings.EnemyPartyAI;

                Battle battle = new Battle(heroes, _levels[i].EnemyParty);
                Party winners = battle.Start();

                if (winners != heroes)
                    return;

                FinishBattle(winners, battle, _levels[i]);
            }

            BattleResults.DisplayGameOver();
        }
        private void GiveItems(List<ItemAmount> items, Party party)
        {
            foreach (ItemAmount itemAmount in items)
            {
                party.Inventory.AddItem(itemAmount.Item, itemAmount.Amount);
            }
        }
        private void FinishBattle(Party winners, Battle battle, Level level)
        {
            var results = new BattleResults(battle);
            results.DisplayResults(level.Rewards);

            GiveItems(level.Rewards, winners);
            battle.Enemies.Inventory.Transfer(winners.Inventory);
        }
    }
}
