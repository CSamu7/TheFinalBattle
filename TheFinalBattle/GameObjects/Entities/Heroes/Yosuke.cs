using TheFinalBattle.GameObjects.Attacks;

namespace TheFinalBattle.GameObjects.Entities.Heroes
{
    public class Yosuke : Entity
    {
        public override int Id { get; init; } = 3;
        public override string Name { get; init; } = "Yosuke";
        public override int MaxHP { get; init; } = 10;
        public override IAttack StandardAttack { get; init; } = new CannonOfConsolas();
    }
}
