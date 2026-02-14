using TheFinalBattle.GameObjects.Attacks;

namespace TheFinalBattle.GameObjects.Entities.Enemies
{
    public class JackFrost : Entity
    {
        public override int Id { get; init; } = 8;
        public override string Name { get; init; } = "Jack Frost";
        public override int MaxHP { get; init; } = 8;
        public override IAttack StandardAttack { get; init; } = new Bufu();
    }
}
