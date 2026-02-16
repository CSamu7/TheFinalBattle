using TheFinalBattle.GameObjects.Attacks;
using TheFinalBattle.GameObjects.Entities;
using TheFinalBattle.UI;

namespace TheFinalBattle.PlayerCommands
{
    public class AttackCommand : IEntityCommand
    {
        private readonly static Random _random = new Random();
        private readonly AttackCommandUI _commandUI;
        private readonly Attack _attack;
        private readonly Entity _defensor;
        public AttackCommand(Attack attack, Entity defensor)
        {
            _attack = attack;
            _defensor = defensor;
            _commandUI = new(defensor, attack);
        }
        public void Execute(Entity attacker)
        {
            ProccessedAttack proccesedAttack = ProcessAttack(attacker);
            bool attackIsSuccessful = proccesedAttack.NewDataAttack.Success >= proccesedAttack.RandomSuccess;

            if (attackIsSuccessful)
            {
                _commandUI.DisplayModifierInSuccessAttack(proccesedAttack);
                _defensor.HP -= proccesedAttack.NewDataAttack.DamagePoints;
                _commandUI.DisplayAttackInfo(attacker, proccesedAttack.NewDataAttack.DamagePoints);
            } else
            {
                _commandUI.DisplayModifierInFailAttack(proccesedAttack);
                _commandUI.FailAttack(attacker);
            }
        }
        public ProccessedAttack ProcessAttack(Entity attacker)
        {
            AttackData attackData = _attack.CalculateAttack();

            AttackData defensorAttackData =
                _defensor.AttackModifier is not null && _defensor.AttackModifier.IsDefensive
                    ? _defensor.AttackModifier.ModifyAttack(attackData)
                    : attackData;

            AttackData finalAttackData =
                attacker.AttackModifier is not null && !attacker.AttackModifier.IsDefensive
                    ? attacker.AttackModifier.ModifyAttack(defensorAttackData)
                    : defensorAttackData;

            double rndSuccess = _random.NextDouble();

            ProccessedAttack attackEventData = new
                (attacker, _defensor, attackData, finalAttackData, _attack, rndSuccess);

            return attackEventData;
        }
    }
}
