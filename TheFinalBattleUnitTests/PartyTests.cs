using TheFinalBattle;

namespace TheFinalBattleUnitTests
{
    [TestClass]
    public sealed class PartyTests
    {
        [TestMethod]
        public void RemoveDeadMembers_MemberIsDead_MemberIsRemoved()
        {
            Inventory enemyInv = new Inventory();
            TrueProgrammer programmer = new TrueProgrammer("Dummy");
            
            programmer.Gear = new Sword();
            programmer.HP = 0;

            Party heroes = new Party(new PartyAI(), programmer);
            
            heroes.RemoveDeadMembers(enemyInv);

            bool isGearInEnemyInv = enemyInv.Items.ContainsKey(new Sword().ID);

            CollectionAssert.DoesNotContain(heroes.Members, programmer);
            Assert.IsTrue(isGearInEnemyInv);
        }
    }
}
