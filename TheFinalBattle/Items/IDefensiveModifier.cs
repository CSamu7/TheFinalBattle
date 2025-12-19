using TheFinalBattle.Attacks;
using TheFinalBattle.PlayableClasses;

namespace TheFinalBattle.Items
{
    public interface IDefensiveModifier : IGameObject
    {
        public string GetSuccessfulMessage(Entity defensor);
        public AttackData AdjustAttack(AttackData attackData);
    }
}
