using TheFinalBattle.Attacks;
using TheFinalBattle.PlayableClasses;

namespace TheFinalBattle.Items
{
    public interface IDefensiveModifier
    {
        public string Name { get; init; }
        public string GetSuccessfulMessage(Entity defensor);
        public AttackData AdjustAttack(AttackData attackData);
    }
}
