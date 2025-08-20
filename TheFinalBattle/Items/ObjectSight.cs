using TheFinalBattle.Attacks;
using Utils;

namespace TheFinalBattle.Items
{
    public class ObjectSight : IDefensiveModifier
    {
        public string Message { get; init; } = "The damage has been reduced!";
        public AttackData AdjustAttack(AttackData attackData)
        {
            //Check that the damage isn't reduced to -1 or -2
            if (attackData.DamageType.Equals(DamageType.Decoding))
            {
                int reducedDamage = attackData.Damage - 2;

                if (reducedDamage < 0) reducedDamage = 0;

                return attackData with { Damage = reducedDamage };
            }
            
            return attackData;
        }
    }
}
