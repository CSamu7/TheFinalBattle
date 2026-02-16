using TheFinalBattle.GameObjects.Attacks;

namespace TheFinalBattle.GameObjects.Entities.Enemies
{
    public class Fairy : Entity
    {
        public override string Name { get; init; } = "Fairy";
        public override int MaxHP { get; init; } = 5;
        public override Attack StandardAttack { get; init; } = new IceBreeze();
    }
}
