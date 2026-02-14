using TheFinalBattle.GameObjects.Attacks;
using TheFinalBattle.GameObjects.Entities;

namespace TheFinalBattle.GameObjects.DefensiveModifiers
{
    public class ObjectSight : AbstractAttackModifier
    {
        public override string Name { get; init; } = "Object Sight";
        public override bool IsDefensive => true;
        public override string GetSuccessfulMessage(Entity holder)
            => $"{holder.Name} has become abstract!";
        public override AttackData ModifyAttack(AttackData attackData)
        {
            AttackData newData = attackData with { };

            if (attackData.DamageType.Equals(DamageType.Decoding))
            {
                int reducedDamage = newData.DamagePoints - 2;
                newData = newData with { DamagePoints = reducedDamage };
            }

            return newData;
        }
    }
}
