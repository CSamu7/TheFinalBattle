using TheFinalBattle.Items;

namespace TheFinalBattle
{
    public record SlotInventory(Item Item, int Amount = 1);
    public class Inventory
    {
        public List<SlotInventory> Items { get; init; } = new List<SlotInventory>();
        public void AddItem(Item item, int amount = 1)
        {
            int index = Items.FindIndex(slot => slot.Item == item);

            if (index == -1)
            {
                Items.Add(new SlotInventory(item, amount));
            } else
            {
                Items[index] = Items[index] with { Amount = amount + Items[index].Amount };
            }
        }
        public void TransferInventory(Inventory invDestiny)
        {
            foreach (SlotInventory invItem in Items)
            {
                invDestiny.AddItem(invItem.Item, invItem.Amount);
            }

            Items.Clear();
        }
        public void RemoveItem(Item itemToRemove, int amount = 1)
        {
            int index = Items.FindIndex(slot => slot.Item == itemToRemove);

            if (index == -1) return;

            if (Items[index].Amount <= amount)
            {
                Items.RemoveAt(index);
            } else
            {
                Items[index] = Items[index] with { Amount = Items[index].Amount - amount };
            }
        }
    }
}
