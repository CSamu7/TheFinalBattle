using TheFinalBattle.Attacks;
using TheFinalBattle.PlayableClasses;

namespace TheFinalBattle.Items
{
    public class KingFrostCape : IDefensiveModifier
    {
        public int Id { get; init; } = 4;
        public string Name { get; init; } = "King Frost Cape";
        public AttackData AdjustAttack(AttackData attackData)
        {
            if (attackData.DamageType.Equals(DamageType.Ice))
            {
                attackData = attackData with { Damage = 1 };
            }

            return attackData;
        }
        public string GetSuccessfulMessage(Entity defensor)
        {
            return $"The cape has protected {defensor.Name} from the cold...";
        }
    }
}
