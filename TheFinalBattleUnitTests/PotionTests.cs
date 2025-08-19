using TheFinalBattle;
using TheFinalBattle.Items;
using TheFinalBattle.PlayerCommands;

namespace TheFinalBattleUnitTests
{
    [TestClass]
    public sealed class PotionTests
    {
        [TestMethod]
        public void EffectHeal_HealPlayerHP_DontOverpassPlayerHP()
        {
            TrueProgrammer programmer = new TrueProgrammer("Dummy");
            Inventory inventory = new Inventory();
            HealthPotion potion = new HealthPotion();
            UseItem command = new UseItem(potion, inventory);

            programmer.HP = 20;
            inventory.AddItem(potion.ID, 1);
            command.Execute(programmer);

            Assert.AreEqual(programmer.HP, 25);
        }
    }
}
