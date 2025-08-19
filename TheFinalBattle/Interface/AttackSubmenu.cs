using TheFinalBattle.Attacks;
using TheFinalBattle.PlayableClasses;
using TheFinalBattle.PlayerCommands;

namespace TheFinalBattle.Interface
{
    public interface ICommandCreation
    {
        public IEntityCommand? BuildCommand();
    }
    public class AttackSubmenu : ICommandCreation
    {
        private readonly EnemiesSubmenu _enemiesSubmenu;
        private readonly AttacksSubmenu _attacksSubmenu;
        private readonly Party _enemies;
        public AttackSubmenu(Party enemies, Entity entity) {
            _enemiesSubmenu = new EnemiesSubmenu(entity, enemies);
            _attacksSubmenu = new AttacksSubmenu(entity);
            _enemies = enemies;
        }
        public IEntityCommand? BuildCommand()
        {
            while (true)
            {
                Entity? enemy = _enemiesSubmenu.SelectEnemy();
                if (enemy is null) return null;

                //Loop infinito
                IAttack? attack = _attacksSubmenu.SelectAttack();

                if (_enemies.Length == 1 && attack is null) return null;
                if (attack is null) continue;

                return new Attack(attack, enemy);
            }
        }
    }
}
