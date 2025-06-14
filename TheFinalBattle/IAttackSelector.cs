namespace TheFinalBattle
{
    public interface IAttackSelector
    {
        int SelectEnemy();
        AttackCommand GetAttack(Entity player);
    }
    public class AttackSelectorAI : IAttackSelector
    {
        private readonly Party _enemies;
        public AttackSelectorAI(Party enemies) { 
            _enemies = enemies;
        }
        public AttackCommand GetAttack(Entity player)
        {
            int enemyIndex = SelectEnemy();
            Entity enemy = _enemies.GetMemberAt(enemyIndex);

            return new AttackCommand(player.StandardAttack, enemy);
        } 
        public int SelectEnemy() {
            Random rnd = new Random();
            int enemyIndex = rnd.Next(_enemies.Length);

            return enemyIndex;
        }  
    }

}
