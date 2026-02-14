using TheFinalBattle.PlayerCommands.Attacks;

namespace TheFinalBattle.GameObjects.Entities.Enemies
{
    public class WealthHand : Entity
    {
        public override int Id { get; init; } = 1;
        public override string Name { get; init; } = "Wealth Hand";
        public override int MaxHP { get; init; } = 12;
        public override IAttack StandardAttack { get; init; } = new Slap();
    }
}
