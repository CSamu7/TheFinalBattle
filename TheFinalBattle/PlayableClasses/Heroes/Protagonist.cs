using TheFinalBattle.Items;
using TheFinalBattle.PlayerCommands.Attacks;

namespace TheFinalBattle.PlayableClasses.Heroes
{
    public class Protagonist : Entity
    {
        public override int Id { get; init; } = 1;
        public override string Name { get; init; }
        public override int MaxHP { get; init; } = 25;
        public override IAttack StandardAttack { get; init; } = new Slap();
        public Protagonist(string name)
        {
            Name = name;
            Gear = new Misericorde();
            DefensiveModifier = new ObjectSight();
        }
    }
}
