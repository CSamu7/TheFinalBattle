using TheFinalBattle.GameObjects.Entities;
using TheFinalBattle.PlayerCommands.Attacks;

namespace TheFinalBattle.GameObjects.DefensiveModifiers
{
    public class ObjectSight : AbstractDefensiveModifier
    {
        public override string Name { get; init; } = "Object Sight";
        public override string GetSuccessfulMessage(Entity defensor)
        {
            return $"bye bye";
        }
        public override AttackData ModifyAttack(AttackData attackData)
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
