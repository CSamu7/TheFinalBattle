using TheFinalBattle.PlayerCommands.Attacks;

namespace TheFinalBattle.GameObjects.Entities.Enemies
{
    public class Mothman : Entity
    {
        public override int Id { get; init; } = 8;
        public override string Name { get; init; } = "Mothman";
        public override int MaxHP { get; init; } = 8;
        public override IAttack StandardAttack { get; init; } = new Zionga();
    }
}
