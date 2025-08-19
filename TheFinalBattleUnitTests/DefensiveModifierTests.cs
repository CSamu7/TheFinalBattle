using TheFinalBattle.Attacks;
using TheFinalBattle.PlayableClasses.Enemies;

namespace TheFinalBattleUnitTests
{
    [TestClass]
    public sealed class DefensiveModifierTests
    {
        [TestMethod]
        public void AdjustAttack_ReduceDamage_DamageDataTo1()
        {
            AttackData data = new AttackData(5, 1);
            StoneAmarok enemy = new StoneAmarok();

            AttackData modifiedData = enemy.DefensiveModifier.AdjustAttack(data);

            Assert.IsTrue(modifiedData.Damage == 1);
        }
    }
}
