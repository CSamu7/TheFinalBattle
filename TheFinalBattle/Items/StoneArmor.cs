using TheFinalBattle.Attacks;

namespace TheFinalBattle.Items
{
    public class StoneArmor : IDefensiveModifier
    {
        public string Message { get; init; } = "STONE ARMOR reduced the attack by 1 point";
        public AttackData AdjustAttack(AttackData attackData)
        {
            return attackData with { Damage = 1 };
        }
    }
}
