using TheFinalBattle.Items;
using TheFinalBattle.Attacks;

namespace TheFinalBattle.PlayableClasses.Heroes
{
    public class TrueProgrammer : Entity
    {
        public override string Name { get; init; }
        public override int MaxHP { get; init; } = 25;
        public override IAttack StandardAttack { get; init; } = new Punch();
        public TrueProgrammer(string name)
        {
            Name = name;
            Gear = new Sword();
            DefensiveModifier = new ObjectSight();
        }
    }
}
