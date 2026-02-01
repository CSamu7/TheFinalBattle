using TheFinalBattle.GameObjects.DefensiveModifiers;
using TheFinalBattle.PlayerCommands.Attacks;

namespace TheFinalBattle.Tests.AttackModifierTests
{
    public class KingFrostCapeTests
    {
        [Fact]
        public void Reduce_damage_if_attack_is_ice_type()
        {
            KingFrostCape modifier = new KingFrostCape();
            TestWeapon testWeapon = new TestWeapon(DamageType.Ice);
            var attackData = testWeapon.CalculateAttack();

            AttackData newData = modifier.ModifyAttack(attackData);

            Assert.True(newData.DamagePoints == 1);
        }

        [Theory]
        [InlineData(DamageType.Range)]
        [InlineData(DamageType.Electric)]
        [InlineData(DamageType.Decoding)]
        public void Do_nothing_if_is_not_ice_damage(DamageType damageType)
        {
            KingFrostCape modifier = new KingFrostCape();
            TestWeapon testWeapon = new TestWeapon(damageType);
            var attackData = testWeapon.CalculateAttack();

            AttackData newData = modifier.ModifyAttack(attackData);

            Assert.True(newData.DamagePoints == 5);
        }
    }
}
