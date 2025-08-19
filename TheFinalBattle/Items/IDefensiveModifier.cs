using TheFinalBattle.Attacks;

namespace TheFinalBattle.Items
{
    public interface IDefensiveModifier
    {
        public string Message { get; init; }
        public AttackData AdjustAttack(AttackData attackData);
    }
}
