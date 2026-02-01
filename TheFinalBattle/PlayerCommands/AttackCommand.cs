using TheFinalBattle.GameObjects.Entities;
using TheFinalBattle.PlayerCommands.Attacks;
using Utils;

namespace TheFinalBattle.PlayerCommands
{
    public class AttackCommand : IEntityCommand
    {
        private IAttack _attack;
        private Entity _enemy;

        //public AttackCommand(AttackEvent attack)
        public AttackCommand(IAttack attack, Entity enemy)
        {
            _attack = attack;
            _enemy = enemy;
        }
        public void Execute(Entity player)
        {
            AttackData attackData = _attack.CalculateAttack();
            
            Random rnd = new Random();
            double rndSuccess = rnd.NextDouble();

            if (attackData.Success > rndSuccess)
            {
                AttackData attackDataModified = _enemy.DefensiveModifier?.ModifyAttack(attackData) ?? attackData;

                if (attackDataModified != attackData)
                {
                    string msg = _enemy.DefensiveModifier?.GetSuccessfulMessage(player) ?? "";
                    Console.WriteLine(msg);
                }

                SuccessAttack(player, attackDataModified.DamagePoints);
            } else
            {
                FailAttack(player);
            }
        }

        //TODO: Mover a una AttackCommandUI clase.
        private void SuccessAttack(Entity player, int damage)
        {
            _enemy.HP -= damage;
            if (_enemy.HP < 0) _enemy.HP = 0;

            Console.WriteLine($"{player.Name.ToUpper()} used {_attack.Name.ToUpper()} on {_enemy.Name.ToUpper()}");
            Console.WriteLine($"{_attack.Name.ToUpper()} dealt {damage} damage to {_enemy.Name.ToUpper()} ");
            Console.WriteLine($"{_enemy.Name.ToUpper()} is now at {_enemy.HP}/{_enemy.MaxHP}");
        }

        private void FailAttack(Entity player)
        {
            ConsoleUtils.WriteLine($"{player.Name.ToUpper()} fail its attack!", ConsoleColor.Red);
        }

    }
}
