using TheFinalBattle.GameObjects.Entities;
using TheFinalBattle.PlayerCommands.Attacks;

namespace TheFinalBattle.GameObjects.DefensiveModifiers
{
    internal class AtiumBead : AbstractDefensiveModifier
    {
        public override string Name { get; init; } = "Atium Bead";
        public override AttackData ModifyAttack(AttackData attackData)
        {
            return attackData with { Success = attackData.Success - .1 };
        }
        public override string GetSuccessfulMessage(Entity defensor)
        {
            return $"{defensor.Name} saw the future and evaded the attack!";
        }
    }
}
