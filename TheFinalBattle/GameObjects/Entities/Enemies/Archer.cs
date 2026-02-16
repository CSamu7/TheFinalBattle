using TheFinalBattle.GameObjects.Attacks;

namespace TheFinalBattle.GameObjects.Entities.Enemies
{
    public class Archer : Entity
    {
        public override string Name { get; init; } = "Archer";
        public override int MaxHP { get; init; } = 8;
        public override Attack StandardAttack { get; init; } = new QuickShot();
    }
}
