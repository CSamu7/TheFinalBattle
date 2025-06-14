namespace TheFinalBattle
{
    internal class Battles
    {
        private EnemyFactory _enemiesFactory;
        private Party _enemies;
        private int _levelNumber = 1;
        public Battles(Party enemies)
        {
            _enemies = enemies;
            _enemiesFactory = new EnemyFactory(enemies.Control);
        }
        public void StartBattles(Party heroes)
        {
            while(heroes.Length > 0)
            {
                List<Entity>? enemies = _enemiesFactory.CreateEnemies(_levelNumber);
                if (enemies is null) break;
                _enemies.AddMembers(enemies);

                Console.Clear();
                Battle battle = new Battle(heroes, _enemies);
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
