using TheFinalBattle.Items;

namespace TheFinalBattle.Tests
{
    public class InventoryTests
    {
        private Inventory _inventory;
        public InventoryTests() { 
             _inventory = new Inventory();
        }
        [Fact]
        public void AddItem_IfTheresNoItemSaved_AddToInventory()
        {
            _inventory.AddItem(new Medicine());

            Assert.True(_inventory.Items.Count() == 1);
        }

        [Fact]
        public void AddItem_IfInventoryHasItem_IncreaseAmount()
        {
            //Una mejor forma de añadir miembros a una party
            _inventory.AddItem(new Medicine(), 2);

            Assert.True(_inventory.Items.Count() == 1, $"{_inventory.Items.Count()}");
        }

        [Fact]
        public void RemoveItem_IfAmountToRemoveIsLessThanActualAmount_ReduceAmount()
        {
            _inventory.AddItem(new Medicine(), 3);
            _inventory.RemoveItem(new Medicine(), 2);

            Assert.True(_inventory.Items[0].Amount == 1);
        }

        [Fact]
        public void RemoveItem_IfAmountToRemoveIsEqualThanActualAmount_RemoveItem()
        {
            _inventory.AddItem(new Medicine(), 3);
            _inventory.RemoveItem(new Medicine(), 3);

            Assert.True(_inventory.Items.Count() == 0);
        }

    }
}