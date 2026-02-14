using TheFinalBattle.GameObjects.Attacks;

namespace TheFinalBattle.GameObjects.Entities.Enemies
{
    public class Reaper : Entity
    {
        public override int Id { get; init; } = 10;
        public override string Name { get; init; } = "Reaper";
        public override int MaxHP { get; init; } = 30;
        public override IAttack StandardAttack { get; init; } = new Megidolaon();
    }
}

