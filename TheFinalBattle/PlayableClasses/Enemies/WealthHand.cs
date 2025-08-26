using TheFinalBattle.Attacks;

namespace TheFinalBattle.PlayableClasses.Enemies
{
    public class WealthHand : Entity
    {
        public override string Name { get; init; } = "Wealth Hand";
        public override int MaxHP { get; init; } = 12;
        public override IAttack StandardAttack { get; init; } = new Slap();
    }
}
