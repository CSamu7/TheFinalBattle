using TheFinalBattle.Attacks;
using TheFinalBattle.PlayableClasses;

namespace TheFinalBattle.Items
{
    public class ObjectSight : IDefensiveModifier
    {
        public int Id { get; init; } = 1;
        public string Name { get; init; } = "Object Sight";
        public string GetSuccessfulMessage(Entity defensor)
        {
            return $"bye bye";
        }
        public AttackData AdjustAttack(AttackData attackData)
        {
            if (attackData.DamageType.Equals(DamageType.Decoding))
            {
                int reducedDamage = attackData.Damage - 2;

                if (reducedDamage < 0) reducedDamage = 0;

                attackData = attackData with { Damage = reducedDamage };
            }
            
            return attackData;
        }
    }
}
