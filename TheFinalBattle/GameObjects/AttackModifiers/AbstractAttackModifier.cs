using TheFinalBattle.GameObjects.Attacks;
using TheFinalBattle.GameObjects.Entities;

namespace TheFinalBattle.GameObjects.DefensiveModifiers
{
    public abstract class AbstractAttackModifier
    {
        public abstract string Name { get; init; }
        public abstract string GetSuccessfulMessage(Entity holder);
        public abstract AttackData ModifyAttack(AttackData attackData);
        public abstract bool IsDefensive { get; }
    }
}
