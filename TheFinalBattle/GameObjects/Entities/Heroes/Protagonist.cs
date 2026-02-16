using TheFinalBattle.GameObjects.AttackModifiers;
using TheFinalBattle.GameObjects.Attacks;
using TheFinalBattle.GameObjects.Items;

namespace TheFinalBattle.GameObjects.Entities.Heroes
{
    public class Protagonist : Entity
    {
        public override string Name { get; init; }
        public override int MaxHP { get; init; } = 25;
        public override Attack StandardAttack { get; init; } = new Slap();
        public Protagonist(string name)
        {
            Name = name;
            Gear = new GlassKnife();
            AttackModifier = new ObjectSight();
        }
    }
}
