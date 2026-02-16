using TheFinalBattle.GameObjects.Attacks;
using TheFinalBattle.GameObjects.Entities;

namespace TheFinalBattle.GameObjects.AttackModifiers
{
    public class FrostCape : AbstractAttackModifier
    {
        public override string Name { get; init; } = "Frost Cape";
        public override bool IsDefensive => true;
        public override AttackData ModifyAttack(AttackData attackData)
        {
            AttackData newData = attackData with { };

            if (attackData.DamageType.Equals(DamageType.Ice))
            {
                newData = newData with { DamagePoints = 1 };
            }

            return newData;
        }
        public override string GetSuccessfulMessage(Entity holder)
        {
            return $"The cape has protected {holder.Name} from the cold...";
        }
    }
}
