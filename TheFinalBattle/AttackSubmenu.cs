using Utils;

namespace TheFinalBattle
{
    public class AttackSubmenu : IAttackSelector
    {
        private readonly Party _enemies;
        public AttackSubmenu(Party enemies) {
            _enemies = enemies;
        }
        public IEntityCommand? GetAttack(Entity entity)
        {
            int enemyIndex = SelectEnemy();

            if (enemyIndex == _enemies.Length) return null;
                        
            return new AttackCommand(entity.StandardAttack, _enemies.GetMemberAt(enemyIndex));
        }
        public int SelectEnemy()
        {
            int enemyIndex;

            do
            {
                DisplayMenu(_enemies);

                Console.Write("Enter a number: ");
                if(!int.TryParse(Console.ReadLine(), out enemyIndex)){
                    ConsoleUtils.WriteLine("You have to write a number...", ConsoleColor.Red);
                }

                enemyIndex -= 1;
            }
            while (enemyIndex > _enemies.Length || enemyIndex < 0);

            return enemyIndex;
        }
        private void DisplayMenu(Party enemies)
        {
            Console.WriteLine("=========ENEMY PARTY========");

            for (int i = 0; i < enemies.Length; i++)
            {
                Entity enemy = enemies.GetMemberAt(i);
                Console.WriteLine($" ({i + 1}) {enemy.Name} {enemy.HP}/{enemy.MaxHP}");
            }

            Console.WriteLine($" ({_enemies.Length + 1}) Back");
        }
    } 
}
