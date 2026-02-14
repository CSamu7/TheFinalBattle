using TheFinalBattle.Parties;
using Utils;

namespace TheFinalBattle.UI
{
    public class BattleResults
    {
        //Esta clase hace un monton de cosas
        private Battle _battle;
        public BattleResults(Battle battle)
        {
            _battle = battle;
        }
        public void DisplayResults(List<ItemAmount> rewards)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("The battle has finished!");
            Thread.Sleep(500);

            if (_battle.Heroes.Members.Count <= 0)
            {
                DisplayDefeat();
                return;
            }

            DisplayVictory(rewards);

            Console.WriteLine("The next battle is starting...");
            Thread.Sleep(800);
        }
        public static void DisplayGameOver()
        {
            Console.WriteLine("GAME OVER!");
            Console.WriteLine("Thanks for play");
        }
        private void DisplayVictory(List<ItemAmount> rewards)
        {
            Console.WriteLine("You have won!");
            DisplayItemsStolen();
            DisplayRewards(rewards);
        }
        private void DisplayDefeat()
        {
            ConsoleUtils.WriteLine("You have been defeated...", ConsoleColor.Red);
            Console.WriteLine("End of the game!");
        }

        //Mas o menos, siento que se podría hacer mejor
        private void DisplayItemsStolen()
        {
            Inventory enemyInventory = _battle.Enemies.Inventory;

            if (enemyInventory.Items.Count <= 0)
            {
                ConsoleUtils.WriteLine("The enemies didn't have anything!", ConsoleColor.Red);
            } else
            {
                Console.WriteLine("The enemies had the next items: ");
                DisplayItemList(enemyInventory.Items);
            }
        }

        //Las funciones de aqui siento que no van con esta clase. Sobretodo porque pueden ser usadas por otras.
        private void DisplayRewards(List<ItemAmount> rewards)
        {
            Console.WriteLine("You have won the next items:");
            DisplayItemList(rewards);

            Thread.Sleep(1000);
        }
        public void DisplayItemList(List<ItemAmount> items)
        {
            foreach (ItemAmount item in items)
            {
                item.Item.ToString();
                DisplayItem(item);
            }
        }
        private void DisplayItem(ItemAmount itemInv) =>
            Console.WriteLine($" * {itemInv.Item} x{itemInv.Amount}");
    }
}
