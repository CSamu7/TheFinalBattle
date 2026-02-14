using TheFinalBattle.GameObjects.Items;

namespace TheFinalBattle.Parties
{
    public class ItemAmount(Item item, int amount = 1)
    {
        public Item Item { get; init; } = item;
        public int Amount { get; set; } = amount;
    }
    public class Inventory
    {
        public List<ItemAmount> Items { get; init; } = new List<ItemAmount>();
        public void AddItem(Item item, int amount = 1)
        {
            int index = Items.FindIndex(slot => item.Id == slot.Item.Id);

            if (index == -1)
            {
                Items.Add(new ItemAmount(item, amount));
            } else
            {
                Items[index].Amount += amount;
            }
        }
        public void Transfer(Inventory invDestiny)
        {
            foreach (ItemAmount invItem in Items)
            {
                invDestiny.AddItem(invItem.Item, invItem.Amount);
            }

            Items.Clear();
        }
        public void RemoveItem(Item itemToRemove, int amount = 1)
        {
            int index = Items.FindIndex(slot => slot.Item.Id == itemToRemove.Id);

            if (index == -1) return;

            if (Items[index].Amount <= amount)
            {
                Items.RemoveAt(index);
            } else
            {
                Items[index].Amount -= amount;
            }
        }
    }
}
