using TheFinalBattle.GameObjects.Attacks;

namespace TheFinalBattle.Tests.AttackModifierTests
{
    /// <summary>
    /// Weapon with 5 of damage and 100% of success.
    /// </summary>
    public class TestAttack : Attack
    {
        public override string Name => "Test";
        public override DamageType DamageType { get; }
        public TestAttack(DamageType damageType)
        {
            DamageType = damageType;

        }
        public override AttackData CalculateAttack()
        {
            return new AttackData(5, DamageType);
        }
    }
}
