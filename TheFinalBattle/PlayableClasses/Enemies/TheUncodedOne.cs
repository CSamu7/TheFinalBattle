using TheFinalBattle.Attacks;

namespace TheFinalBattle.PlayableClasses.Enemies
{
    public class TheUncodedOne : Entity
    {
        public override string Name { get; init; } = "The Uncoded One";
        public override int MaxHP { get; init; } = 15;
        public override IAttack StandardAttack { get; init; } = new Unraveling();
    }
}

