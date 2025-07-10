namespace TheFinalBattle
{
    public class Battles
    {
        private PartyEnemyFactory _enemiesFactory;
        private int _levelNumber = 1;
        public Battles(Party enemies)
        {
            _enemiesFactory = new PartyEnemyFactory(enemies.PartyControl);
        }
        public void StartBattles(Party heroes)
        {
            while(heroes.Length > 0)
            {
                Party? enemies = _enemiesFactory.Create(_levelNumber);
                if (enemies is null) break;

                Console.Clear();
                Battle battle = new Battle(heroes, enemies);
                battle.StartBattle();
                _levelNumber++;

                DisplayResult(heroes);
            }
        }
        private void DisplayResult(Party heroes)
        {
            if (heroes.Length <= 0)
            {
                Console.WriteLine("You have been defeated...");
                Console.WriteLine("End of the game!");
            }
            //TODO: The game has finished!!
            Console.WriteLine("You have won!");
            Console.WriteLine("The next battle is starting...");
            Thread.Sleep(1000);
        }
    }
}
