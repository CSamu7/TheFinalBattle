namespace TheFinalBattle
{
    public class BattleResults
    {
        private Party _heroes;
        private Party _enemies;
        public BattleResults(Party heroes, Party enemies) { 
            _heroes = heroes;
            _enemies = enemies;
        }
        public void DisplayResults()
        {
            Console.WriteLine("The battle has finished!");
            Thread.Sleep(500);

            if (_heroes.Length <= 0)
            {
                DisplayDefeat();
                return;
            }
            //TODO: The game has finished!!
            Console.WriteLine("You have won!");
            DisplayItemsWon();

            Console.WriteLine("The next battle is starting...");
            Thread.Sleep(800);
        }
        private void DisplayDefeat()
        {
            Console.WriteLine("You have been defeated...");
            Console.WriteLine("End of the game!");
        }
        private void DisplayItemsWon()
        {
            if(_enemies.Inventory.Items.Count <= 0)
            {
                Console.WriteLine("You have obtained nothing!");
            } else
            {
                Console.WriteLine("You have obtained the next items: ");

                foreach (KeyValuePair<Item, int> item in _enemies.Inventory.Items)
                {
                    Console.WriteLine($" * {item.Key.Name} x{item.Value}");
                    Thread.Sleep(800);
                }
            }

            Thread.Sleep(1000);
        }
    }
}
