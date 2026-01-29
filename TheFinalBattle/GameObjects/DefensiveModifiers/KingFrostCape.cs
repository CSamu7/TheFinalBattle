using TheFinalBattle.GameObjects.Entities;
using TheFinalBattle.PlayerCommands.Attacks;

namespace TheFinalBattle.GameObjects.DefensiveModifiers
{
    public class KingFrostCape : AbstractDefensiveModifier
    {
        public override string Name { get; init; } = "King Frost Cape";
        public override AttackData ModifyAttack(AttackData attackData)
        {
            if (attackData.DamageType.Equals(DamageType.Ice))
                attackData = attackData with { Damage = 1 };

            return attackData;
        }
        public override string GetSuccessfulMessage(Entity defensor)
        {
            return $"The cape has protected {defensor.Name} from the cold...";
        }
    }
}
