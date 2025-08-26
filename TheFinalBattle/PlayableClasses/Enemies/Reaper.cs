using TheFinalBattle.Attacks;

namespace TheFinalBattle.PlayableClasses.Enemies
{
    public class Reaper : Entity
    {
        public override string Name { get; init; } = "Reaper";
        public override int MaxHP { get; init; } = 30;
        public override IAttack StandardAttack { get; init; } = new Megidolaon();
    }
}

