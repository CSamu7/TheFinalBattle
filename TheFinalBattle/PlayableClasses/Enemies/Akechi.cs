using TheFinalBattle.PlayerCommands.Attacks;

namespace TheFinalBattle.PlayableClasses.Enemies
{
    public class Akechi : Entity
    {
        public override int Id { get; init; } = 20;
        public override string Name { get; init; } = "Akechi";
        public override int MaxHP { get; init; } = 20;
        public override IAttack StandardAttack { get; init; } = new Laevateinn();
    }
}
