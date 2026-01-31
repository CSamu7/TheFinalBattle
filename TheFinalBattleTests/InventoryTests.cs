using TheFinalBattle.GameObjects.Items;

namespace TheFinalBattle.Tests
{
    public class InventoryTests
    {
        [Fact]
        public void Add_item_if_there_is_not_in_inventory()
        {
            Inventory inventory = new Inventory();

            inventory.AddItem(new Medicine());

            Assert.True(inventory.Items.Count() == 1);
        }

        [Fact]
        public void Increase_amount_if_item_is_in_inventory()
        {
            Inventory inventory = new Inventory();

            inventory.AddItem(new Medicine(), 2);
            inventory.AddItem(new Medicine(), 2);

            Assert.True(inventory.Items[0].Amount == 4);
        }

        [Fact]
        public void Decrease_amount_if_amount_to_reduce_is_less_than_actual_amount()
        {
            Inventory inventory = new Inventory();

            inventory.AddItem(new Medicine(), 3);
            inventory.RemoveItem(new Medicine(), 2);

            Assert.True(inventory.Items[0].Amount == 1);
        }

        [Fact]
        public void Remove_item_if_amount_to_reduce_is_equal_or_greather_tan_actual_amount()
        {
            Inventory inventory = new Inventory();

            inventory.AddItem(new Medicine(), 3);
            inventory.RemoveItem(new Medicine(), 3);

            Assert.True(inventory.Items.Count() == 0);
        }

    }
}