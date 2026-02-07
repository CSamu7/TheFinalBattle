using TheFinalBattle.GameObjects.Entities;
using TheFinalBattle.PlayerCommands.Attacks;

namespace TheFinalBattle.GameObjects.DefensiveModifiers
{
    public class KingFrostCape : AbstractAttackModifier
    {
        public override string Name { get; init; } = "King Frost Cape";
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
