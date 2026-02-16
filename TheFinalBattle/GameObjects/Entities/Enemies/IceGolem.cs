using TheFinalBattle.GameObjects.Attacks;

namespace TheFinalBattle.GameObjects.Entities.Enemies
{
    public class IceGolem : Entity
    {
        public override string Name { get; init; } = "Ice Golem";
        public override int MaxHP { get; init; } = 8;
        public override Attack StandardAttack { get; init; } = new SnowStorm();
    }
}
