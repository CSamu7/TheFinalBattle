using TheFinalBattle.GameObjects.AttackModifiers;
using TheFinalBattle.GameObjects.Attacks;

namespace TheFinalBattle.GameObjects.Entities.Enemies
{
    public class FireHog : Entity
    {
        public override string Name { get; init; } = "Fire Hog";
        public override int MaxHP { get; init; } = 10;
        public override Attack StandardAttack { get; init; } = new SnowGrave();
        public FireHog()
        {
            AttackModifier = new MagmaStone();
        }
    }
}
