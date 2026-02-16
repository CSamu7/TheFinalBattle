using TheFinalBattle.GameObjects.Attacks;

namespace TheFinalBattle.GameObjects.Entities.Enemies
{
    public class Undefined : Entity
    {
        public override string Name { get; init; } = "Undefined";
        public override int MaxHP { get; init; } = 30;
        public override Attack StandardAttack { get; init; } = new PointerOfPointers();
    }
}

