using TheFinalBattle.GameObjects.Attacks;

namespace TheFinalBattle.GameObjects.Entities.Enemies
{
    public class Skeleton : Entity
    {
        public override string Name { get; init; } = "Skeleton";
        public override int MaxHP { get; init; } = 6;
        public override Attack StandardAttack { get; init; } = new Slap();
    }
}
