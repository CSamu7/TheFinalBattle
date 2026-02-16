using TheFinalBattle.GameObjects.Attacks;
using TheFinalBattle.GameObjects.Entities;
using TheFinalBattle.PlayerCommands;
using Utils;

namespace TheFinalBattle.UI
{
    public class AttackCommandUI
    {
        private readonly Entity _defensor;
        private readonly Attack _attack;
        public AttackCommandUI(Entity defensor, Attack attack)
        {
            _defensor = defensor;
            _attack = attack;
        }
        public void DisplayAttackInfo(Entity attacker, int damage)
        {
            Console.WriteLine($"{attacker.Name.ToUpper()} used {_attack.Name.ToUpper()} on {_defensor.Name.ToUpper()}");
            Console.WriteLine($"{_attack.Name.ToUpper()} dealt {damage} damage to {_defensor.Name.ToUpper()} ");
            Console.WriteLine($"{_defensor.Name.ToUpper()} is now at {_defensor.HP}/{_defensor.MaxHP}");

            Thread.Sleep(700);
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

            if (attacker.AttackModifier is not null)
            {
                if (prevDamage > actualDamage && !attacker.AttackModifier.IsDefensive)
                {
                    string msg = attacker.AttackModifier?.GetSuccessfulMessage(attacker) ?? "";
                    ConsoleUtils.WriteLine(msg, ConsoleColor.Blue);
                } else if (actualDamage < prevDamage)
                {
                    string msg = _defensor.AttackModifier?.GetSuccessfulMessage(_defensor) ?? "";
                    ConsoleUtils.WriteLine(msg, ConsoleColor.Blue);
                }
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
