using TheFinalBattle.GameObjects.AttackModifiers;
using TheFinalBattle.GameObjects.Attacks;

namespace TheFinalBattle.Tests.AttackModifierTests
{
    public class AtiumBeadTests
    {
        [Fact]
        public void Reduce_attack_success()
        {
            Atium modifier = new Atium();
            TestWeapon testWeapon = new TestWeapon(DamageType.Decoding);
            AttackData attackData = testWeapon.CalculateAttack();

            AttackData newData = modifier.ModifyAttack(attackData);

            Assert.Equal(.8, newData.Success);
        }
    }
}
