using TheFinalBattle.GameObjects.Attacks;

namespace TheFinalBattle.GameObjects.Entities.Enemies
{
    public class Mara : Entity
    {
        public override int Id { get; init; } = 10;
        public override string Name { get; init; } = "Mara";
        public override int MaxHP { get; init; } = 10;
        public override IAttack StandardAttack { get; init; } = new AssaultDive();
    }
}
