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
            //TODO: No me gusta que se modifique el ataque original, en todo caso se debería que crear una copia.
            if (attackData.DamageType.Equals(DamageType.Ice))
                attackData = attackData with { DamagePoints = 1 };

            return attackData;
        }
        public override string GetSuccessfulMessage(Entity defensor)
        {
            return $"The cape has protected {defensor.Name} from the cold...";
        }
    }
}
