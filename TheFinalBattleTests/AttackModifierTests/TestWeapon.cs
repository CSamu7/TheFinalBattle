using TheFinalBattle.PlayerCommands.Attacks;

namespace TheFinalBattle.Tests.AttackModifierTests
{
    /// <summary>
    /// Weapon with 5 of damage and 100% of success.
    /// </summary>
    public class TestWeapon : IAttack
    {
        public string Name => "Test";
        public DamageType DamageType { get; init; }
        public TestWeapon(DamageType damageType)
        {
            DamageType = damageType;

        }
        public AttackData CalculateAttack()
        {
            return new AttackData(5, DamageType);
        }
    }
}
