using TheFinalBattle.Attacks;
using TheFinalBattle.PlayableClasses;

namespace TheFinalBattle.Items
{
    internal class AtiumBead : IDefensiveModifier
    {
        public string Name { get; init; } = "Atium Bead";
        public int Id { get; init; } = 1;
        public AttackData AdjustAttack(AttackData attackData)
        {
            return attackData with { Success = attackData.Success - .1 };
        }
        public string GetSuccessfulMessage(Entity defensor)
        {
            return $"{defensor.Name} saw the future and evaded the attack!";
        }
    }
}
