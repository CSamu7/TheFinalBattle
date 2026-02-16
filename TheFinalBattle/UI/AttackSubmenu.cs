using TheFinalBattle.GameObjects.Attacks;
using TheFinalBattle.GameObjects.Entities;
using TheFinalBattle.Parties;
using TheFinalBattle.PlayerCommands;

namespace TheFinalBattle.UI
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
        public AttackSubmenu(Party enemies, Entity entity)
        {
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
                Attack? attack = _attacksSubmenu.SelectAttack();

                if (_enemies.Members.Count == 1 && attack is null) return null;
                if (attack is null) continue;

                return new AttackCommand(attack, enemy);
            }
        }
    }
}
