using TheFinalBattle.GameObjects.AttackModifiers;
using TheFinalBattle.GameObjects.Attacks;

namespace TheFinalBattle.Tests.AttackModifierTests
{
    public class ObjectSightTests
    {
        [Fact]
        public void Reduce_damage_if_attack_is_decoding_type()
        {
            ObjectSight sut = new ObjectSight();
            TestAttack testAttack = new TestAttack(DamageType.Decoding);
            AttackData attackData = testAttack.CalculateAttack();

            AttackData newData = sut.ModifyAttack(attackData);

            Assert.Equal(3, newData.DamagePoints);
        }
    }
}
