using TheFinalBattle;

namespace TheFinalBattleUnitTests
{
    [TestClass]
    public sealed class InventoryTests
    {
        [TestMethod]
        public void AddItem_SingleItem_ItemIsAddToDictionary()
        {
            Inventory inventory = new Inventory();

            inventory.AddItem(1, 2);

            inventory.Items.TryGetValue(1, out int amount);
            Assert.AreEqual(amount, 2);
        }
        public void AddItem_InvalidIDItem_IDItemIsRejected()
        {
            Inventory inventory = new Inventory();

            Assert.ThrowsException<ArgumentException>(() => inventory.AddItem(30000, 2));
        }

        [TestMethod]
        public void AddItem_ItemItsAlreadyInInventory_IncrementAmount()
        {
            Inventory inventory = new Inventory();

            inventory.AddItem(1, 2);
            inventory.AddItem(1, 2);

            inventory.Items.TryGetValue(1, out int amount);
            Assert.AreEqual(amount, 4);
        }

        [TestMethod]
        //Cambiar nombre
        public void RemoveItem_TheAmountToRemoveIsEqualToTheAmountSaved_RemoveItemFromDictionary()
        {
            Inventory inventory = new Inventory();
            inventory.AddItem(1, 2);

            inventory.RemoveItem(1, 2);
            Assert.IsFalse(inventory.Items.ContainsKey(1));
        }

        [TestMethod]
        public void RemoveItem_TheAmountToRemoveIsLessToTheAmountSaved_DecreaseAmount()
        {
            Inventory inventory = new Inventory();
            inventory.AddItem(1, 2);

            inventory.RemoveItem(1, 1);
            inventory.Items.TryGetValue(1, out int amount);
            Assert.AreEqual(amount, 1);
        }
    }
}
