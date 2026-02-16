using TheFinalBattle.GameObjects.AttackModifiers;
using TheFinalBattle.GameObjects.Attacks;

namespace TheFinalBattle.Tests.AttackModifierTests
{
    public class KingFrostCapeTests
    {
        [Fact]
        public void Reduce_damage_if_attack_is_ice_type()
        {
            FrostCape modifier = new FrostCape();
            TestWeapon testWeapon = new TestWeapon(DamageType.Ice);
            var attackData = testWeapon.CalculateAttack();

            AttackData newData = modifier.ModifyAttack(attackData);

            Assert.True(newData.DamagePoints == 1);
        }

        [Theory]
        [InlineData(DamageType.Range)]
        [InlineData(DamageType.Fire)]
        [InlineData(DamageType.Decoding)]
        public void Do_nothing_if_is_not_ice_damage(DamageType damageType)
        {
            FrostCape modifier = new FrostCape();
            TestWeapon testWeapon = new TestWeapon(damageType);
            var attackData = testWeapon.CalculateAttack();

            AttackData newData = modifier.ModifyAttack(attackData);

            Assert.True(newData.DamagePoints == 5);
        }
    }
}
