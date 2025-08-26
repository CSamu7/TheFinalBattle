using TheFinalBattle.Attacks;

namespace TheFinalBattle.PlayableClasses.Enemies
{
    public class Mara : Entity
    {
        public override string Name { get; init; } = "Mara";
        public override int MaxHP { get; init; } = 10;
        public override IAttack StandardAttack { get; init; } = new AssaulDive();
    }
}
