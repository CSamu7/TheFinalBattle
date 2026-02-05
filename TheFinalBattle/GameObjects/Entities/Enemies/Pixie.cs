using TheFinalBattle.GameObjects.DefensiveModifiers;
using TheFinalBattle.PlayerCommands.Attacks;

namespace TheFinalBattle.GameObjects.Entities.Enemies
{
    public class Pixie : Entity
    {
        public override int Id { get; init; } = 7;
        public override string Name { get; init; } = "Pixie";
        public override int MaxHP { get; init; } = 5;
        public override IAttack StandardAttack { get; init; } = new Zio();
        public Pixie()
        {
            AttackModifier = new AtiumBead();
        }
    }
}
