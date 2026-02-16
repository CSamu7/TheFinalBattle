using TheFinalBattle.GameObjects.Attacks;
using TheFinalBattle.GameObjects.Items;
using TheFinalBattle.Tests.AttackModifierTests;

namespace TheFinalBattle.Tests
{
    public record TestGear() : Gear(999, "Test Gear", "For unit testing", new TestAttack(DamageType.Ice));

}
