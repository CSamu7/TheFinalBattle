using TheFinalBattle.GameObjects.Entities;
using TheFinalBattle.PlayerCommands.Attacks;
using TheFinalBattle.UI;

namespace TheFinalBattle.PlayerCommands
{
    public class AttackCommand : IEntityCommand
    {
        private static Random _random = new Random();
        private readonly AttackCommandUI _commandUI;
        private readonly IAttack _attack;
        private readonly Entity _defensor;
        public AttackCommand(IAttack attack, Entity defensor)
        {
            _attack = attack;
            _defensor = defensor;
            _commandUI = new(defensor, attack);
        }
        public void Execute(Entity attacker)
        {
            AttackData attackData = _attack.CalculateAttack();
            AttackData newAttackData = _defensor.AttackModifier?.ModifyAttack(attackData) ?? attackData;
            
            double rndSuccess = _random.NextDouble();

            if (attackData.Success > rndSuccess)
            {
                _commandUI.ModifierReduceDamage(attackData.DamagePoints, newAttackData.DamagePoints, attacker);
                _defensor.HP -= newAttackData.DamagePoints;
                _commandUI.SuccessAttack(attacker, newAttackData.DamagePoints);
            } else
            {
                if (attackData.Success > rndSuccess && rndSuccess > newAttackData.Success) 
                {
                    _commandUI.ModifierAvoidAttack(attacker);
                }

                _commandUI.FailAttack(attacker);
            }
        }
    }
}
