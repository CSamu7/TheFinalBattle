using TheFinalBattle.Attacks;

namespace TheFinalBattle.PlayableClasses.Enemies
{
    public class Pixie : Entity
    {
        public override string Name { get; init; } = "Pixie";
        public override int MaxHP { get; init; } = 5;
        public override IAttack StandardAttack { get; init; } = new Zio();
    }
}
