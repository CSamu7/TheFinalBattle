using TheFinalBattle.GameObjects.Attacks;
using TheFinalBattle.GameObjects.Entities;

namespace TheFinalBattle.GameObjects.AttackModifiers
{
    public class Atium : AbstractAttackModifier
    {
        public override string Name { get; init; } = "Atium";
        public override bool IsDefensive => true;
        public override AttackData ModifyAttack(AttackData attackData)
        {
            return attackData with { Success = attackData.Success - .2 };
        }
        public override string GetSuccessfulMessage(Entity holder)
            => $"{holder.Name} saw the future and evaded the attack!";
    }
}
