using TheFinalBattle.GameObjects.AttackModifiers;
using TheFinalBattle.GameObjects.Attacks;

namespace TheFinalBattle.Tests.AttackModifierTests
{
    public class KingFrostCapeTests
    {
        [Fact]
        public void Reduce_damage_if_attack_is_ice_type()
        {
            FrostCape sut = new FrostCape();
            TestAttack testAttack = new TestAttack(DamageType.Ice);
            var attackData = testAttack.CalculateAttack();

            AttackData newData = sut.ModifyAttack(attackData);

            Assert.True(newData.DamagePoints == 1);
        }

        [Theory]
        [InlineData(DamageType.Range)]
        [InlineData(DamageType.Fire)]
        [InlineData(DamageType.Decoding)]
        public void Do_nothing_if_is_not_ice_damage(DamageType damageType)
        {
            FrostCape modifier = new FrostCape();
            TestAttack testWeapon = new TestAttack(damageType);
            var attackData = testWeapon.CalculateAttack();

            AttackData newData = modifier.ModifyAttack(attackData);

            Assert.True(newData.DamagePoints == 5);
        }
    }
}
