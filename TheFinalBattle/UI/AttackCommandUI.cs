using TheFinalBattle.GameObjects.Entities;
using TheFinalBattle.PlayerCommands.Attacks;
using Utils;

namespace TheFinalBattle.UI
{
    public class AttackCommandUI
    {
        private readonly Entity _defensor;
        private readonly IAttack _attack;
        public AttackCommandUI(Entity defensor, IAttack attack) { 
            _defensor = defensor;
            _attack = attack;
        }
        public void SuccessAttack(Entity player, int damage)
        {
            Console.WriteLine($"{player.Name.ToUpper()} used {_attack.Name.ToUpper()} on {_defensor.Name.ToUpper()}");
            Console.WriteLine($"{_attack.Name.ToUpper()} dealt {damage} damage to {_defensor.Name.ToUpper()} ");
            Console.WriteLine($"{_defensor.Name.ToUpper()} is now at {_defensor.HP}/{_defensor.MaxHP}");
        }
        public void FailAttack(Entity player)
        {
            ConsoleUtils.WriteLine($"{player.Name.ToUpper()} fail its attack!", ConsoleColor.Red);
        }

        public void ModifierReduceDamage(int oldDamage, int newDamage, Entity attacker)
        {
            if (oldDamage > newDamage)
            {
                string msg = _defensor.AttackModifier?.GetSuccessfulMessage(attacker) ?? "";
                Console.WriteLine(msg);
            }
        }
        public void ModifierAvoidAttack(Entity attacker)
        {
            string msg = _defensor.AttackModifier?.GetSuccessfulMessage(attacker) ?? "";
            Console.WriteLine(msg);
        }
    }
}
