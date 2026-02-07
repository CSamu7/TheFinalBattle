using TheFinalBattle.GameObjects.AttackModifiers;
using TheFinalBattle.PlayerCommands.Attacks;

namespace TheFinalBattle.Tests.AttackModifierTests
{
    public class MagmaStoneTests
    {
        [Fact]
        public void Increase_attack_when_is_physical()
        {
            MagmaStone modifier = new MagmaStone();
            TestWeapon testWeapon = new TestWeapon(DamageType.Physical);
            AttackData attackData = testWeapon.CalculateAttack();

            AttackData newData = modifier.ModifyAttack(attackData);

            Assert.Equal(7, newData.DamagePoints);
        }
    }
}
