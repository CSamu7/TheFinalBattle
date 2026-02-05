using TheFinalBattle.GameObjects.Entities;
using TheFinalBattle.PlayerCommands;
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
        public void SuccessAttack(Entity attacker, int damage)
        {
            Console.WriteLine($"{attacker.Name.ToUpper()} used {_attack.Name.ToUpper()} on {_defensor.Name.ToUpper()}");
            Console.WriteLine($"{_attack.Name.ToUpper()} dealt {damage} damage to {_defensor.Name.ToUpper()} ");
            Console.WriteLine($"{_defensor.Name.ToUpper()} is now at {_defensor.HP}/{_defensor.MaxHP}");
        }
        public void FailAttack(Entity player)
        {
            ConsoleUtils.WriteLine($"{player.Name.ToUpper()} fail its attack!", ConsoleColor.Red);
        }
        public void DisplayModifierInSuccessAttack(ProccessedAttack attackEventData)
        {
            int prevDamage = attackEventData.OriginalDataAttack.DamagePoints;
            int actualDamage = attackEventData.NewDataAttack.DamagePoints;
            Entity attacker = attackEventData.Attacker;

            if (prevDamage > actualDamage)
            {
                string msg = attacker.AttackModifier?.GetSuccessfulMessage(attacker) ?? "";
                ConsoleUtils.WriteLine(msg, ConsoleColor.Blue);
            } else if (actualDamage < prevDamage)
            {
                string msg = _defensor.AttackModifier?.GetSuccessfulMessage(attacker) ?? "";
                Console.WriteLine(msg);
            }
        }
        public void DisplayModifierInFailAttack(ProccessedAttack attackEvent)
        {
            double successFromWeapon = attackEvent.OriginalDataAttack.Success;
            double successAfterModifiers = attackEvent.NewDataAttack.Success;
            double randomSuccessCalculated = attackEvent.RandomSuccess;
            Entity defensor = attackEvent.Defensor;

            if (successFromWeapon > randomSuccessCalculated && randomSuccessCalculated > successAfterModifiers)
            {
                string msg = _defensor.AttackModifier?.GetSuccessfulMessage(defensor) ?? "";
                ConsoleUtils.WriteLine(msg, ConsoleColor.Blue);
            }
        }
    }
}
