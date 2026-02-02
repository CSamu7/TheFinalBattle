using TheFinalBattle.GameObjects.Entities;
using TheFinalBattle.PlayerCommands.Attacks;

namespace TheFinalBattle.GameObjects.DefensiveModifiers
{
    public class ObjectSight : AbstractAttackModifier
    {
        public override string Name { get; init; } = "Object Sight";
        public override string GetSuccessfulMessage(Entity defensor)
        {
            return $"bye bye";
        }
        public override AttackData ModifyAttack(AttackData attackData)
        {
            //TODO: Estanderizar como se calcula esto.
            if (attackData.DamageType.Equals(DamageType.Decoding))
            {
                int reducedDamage = attackData.DamagePoints - 2;

                if (reducedDamage < 0) reducedDamage = 0;

                attackData = attackData with { DamagePoints = reducedDamage };
            }
            
            return attackData;
        }
    }
}
