using TheFinalBattle.GameObjects.AttackModifiers;
using TheFinalBattle.GameObjects.Attacks;

namespace TheFinalBattle.Tests.AttackModifierTests
{
    public class AtiumBeadTests
    {
        [Fact]
        public void Reduce_attack_success()
        {
            Atium sut = new Atium();
            TestAttack testAttack = new TestAttack(DamageType.Decoding);
            AttackData attackData = testAttack.CalculateAttack();

            AttackData newData = sut.ModifyAttack(attackData);

            Assert.Equal(.8, newData.Success);
        }
    }
}
