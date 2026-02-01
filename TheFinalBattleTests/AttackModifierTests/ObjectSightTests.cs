using TheFinalBattle.GameObjects.DefensiveModifiers;
using TheFinalBattle.PlayerCommands.Attacks;

namespace TheFinalBattle.Tests.AttackModifierTests
{
    public class ObjectSightTests
    {
        [Fact]
        public void Reduce_damage_if_attack_is_decoding_type()
        {
            ObjectSight modifier = new ObjectSight();
            TestWeapon testWeapon = new TestWeapon(DamageType.Decoding);
            AttackData attackData = testWeapon.CalculateAttack();

            AttackData newData = modifier.ModifyAttack(attackData);

            Assert.Equal(3, newData.DamagePoints);
        }
    }
}
