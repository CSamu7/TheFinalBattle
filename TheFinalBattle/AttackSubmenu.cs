using Utils;

namespace TheFinalBattle
{
    public class AttackSubmenu : IAttackSelector
    {
        private readonly Party _enemies;
        public AttackSubmenu(Party enemies) {
            _enemies = enemies;
        }
        public AttackCommand GetAttack(Entity entity)
        {
            while (true)
            {
                int enemyIndex = SelectEnemy();

                if (enemyIndex < _enemies.Length) return
                        new AttackCommand(entity.StandardAttack, _enemies.GetMemberAt(enemyIndex));

                if (enemyIndex == _enemies.Length) return null;
            };
        }
        public int SelectEnemy()
        {
            int enemyOption;

            do
            {
                DisplayMenu(_enemies);

                Console.Write("Enter a number: ");
                if(!int.TryParse(Console.ReadLine(), out enemyOption)){
                    ConsoleUtils.WriteLine("You have to write a number...", ConsoleColor.Red);
                }

                enemyOption -= 1;
            }
            while (enemyOption > _enemies.Length);

            return enemyOption;
        }
        private void DisplayMenu(Party enemies)
        {
            Console.WriteLine("Which enemy do you want to attack? ");

            for (int i = 0; i < enemies.Length; i++)
            {
                Entity enemy = enemies.GetMemberAt(i);
                Console.WriteLine($" ({i + 1}) {enemy.Name} {enemy.HP}/{enemy.MaxHP}");
            }

            Console.WriteLine($" ({_enemies.Length + 1}) Back");
        }
    } 
}
