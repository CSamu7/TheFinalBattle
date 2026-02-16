using TheFinalBattle.GameObjects.AttackModifiers;
using TheFinalBattle.GameObjects.Attacks;

namespace TheFinalBattle.Tests.AttackModifierTests
{
    public class MagmaStoneTests
    {
        [Fact]
        public void Increase_attack_when_is_physical()
        {
            MagmaStone sut = new MagmaStone();
            TestAttack testAttack = new TestAttack(DamageType.Physical);
            AttackData attackData = testAttack.CalculateAttack();

            AttackData newData = sut.ModifyAttack(attackData);

            Assert.Equal(7, newData.DamagePoints);
        }
    }
}
