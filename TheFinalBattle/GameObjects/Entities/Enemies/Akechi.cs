using TheFinalBattle.GameObjects.Entities;
using TheFinalBattle.PlayerCommands.Attacks;

namespace TheFinalBattle.GameObjects.Entities.Enemies
{
    public class Akechi : Entity
    {
        public override int Id { get; init; } = 20;
        public override string Name { get; init; } = "Akechi";
        public override int MaxHP { get; init; } = 20;
        public override IAttack StandardAttack { get; init; } = new Laevateinn();
    }
}
