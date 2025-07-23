namespace TheFinalBattle
{
    public class Inventory
    {
        public Dictionary<Item, int> Items { get; private set; } = new();
        public Inventory() { }
        public void AddItem(Item item, int amount = 1)
        {
            if (Items.ContainsKey(item))
            {
                Items[item] += amount;
            } else
            {
                Items.Add(item, amount);
            }
        }
        public void TransferItem(Inventory inventory, Item item)
        {
            inventory.AddItem(item);
            Items.Remove(item);
        }
        public List<Item> GetItemsByType(ItemType type)
        {
            return Items.Keys.Where(item => item.ItemType.Equals(type)).ToList();
        }
        public bool HasItem(ItemType type)
        {
            return Items.Keys.Any(item => item.ItemType.Equals(type));
        }
        public void RemoveItem(Item item)
        {
            if (Items.ContainsKey(item))
            {
                if (Items[item] <= 1)
                {
                    Items.Remove(item);
                } else
                {
                    Items[item] -= 1;
                }
            }
        }
    }
}
