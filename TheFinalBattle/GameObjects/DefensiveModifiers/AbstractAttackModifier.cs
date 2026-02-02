using TheFinalBattle.GameObjects.Entities;
using TheFinalBattle.PlayerCommands.Attacks;

namespace TheFinalBattle.GameObjects.DefensiveModifiers
{
    public abstract class AbstractAttackModifier
    {
        public abstract string Name { get; init; }
        public abstract string GetSuccessfulMessage(Entity holder);
        public abstract AttackData ModifyAttack(AttackData attackData);
    }
}
