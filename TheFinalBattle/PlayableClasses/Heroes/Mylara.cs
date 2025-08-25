using TheFinalBattle.Attacks;

namespace TheFinalBattle.PlayableClasses.Heroes
{
    public class Mylara : Entity
    {
        public override string Name { get; init; } = "Mylara";
        public override int MaxHP { get; init; } = 10;
        public override IAttack StandardAttack { get; init; } = new CannonOfConsolas();
    }
}
