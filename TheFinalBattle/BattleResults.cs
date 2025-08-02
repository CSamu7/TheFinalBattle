using Utils;

namespace TheFinalBattle
{
    public class BattleResults
    {
        private Battle _battle;
        private ListItems _items = new ListItems();
        public BattleResults(Battle battle) { 
            _battle = battle;
        }
        public static void DisplayGameOver()
        {
            Console.WriteLine("GAME OVER!");
            Console.WriteLine("Thanks for play");
        }
        public void DisplayResults()
        {
            Console.WriteLine("The battle has finished!");
            Thread.Sleep(500);

            if (_battle.Heroes.Length <= 0)
            {
                DisplayDefeat();
                Console.WriteLine("End of the game!");
            } else
            {
                DisplayVictory();
            }

            Console.WriteLine("The next battle is starting...");
            Thread.Sleep(800);
        }
        private void DisplayVictory()
        {
            Console.WriteLine("You have won!");
            DisplayItemsWon();
        }
        private void DisplayDefeat()
        {
            ConsoleUtils.WriteLine("You have been defeated...", ConsoleColor.Red);
        }
        private void DisplayItemsWon()
        {
            Inventory enemyInventory = _battle.Enemies.Inventory;

            if(enemyInventory.Items.Count <= 0)
            {
                Console.WriteLine("The enemies didn't have anything!");
            } else
            {
                Console.WriteLine("You have got the next items: ");

                foreach (KeyValuePair<int, int> itemInv in enemyInventory.Items)
                {
                    Item item = _items.GetItemByID(itemInv.Key);
                    Console.WriteLine($" * {item.Name} x{itemInv.Value}");
                    Thread.Sleep(800);
                }
            }

            Thread.Sleep(1000);
        }
    }
}
