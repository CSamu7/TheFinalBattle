using TheFinalBattle.GameObjects.Attacks;

namespace TheFinalBattle.GameObjects.Entities.Enemies
{
    public class TheUncodedOne : Entity
    {
        public override string Name { get; init; } = "The Uncoded One";
        public override int MaxHP { get; init; } = 12;
        public override Attack StandardAttack { get; init; } = new Unraveling();
    }
}
