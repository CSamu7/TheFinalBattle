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
            inventory.AddItem(item, Items[item]);
            Items.Remove(item);
        }
        public bool HasItem<T>()
        {
            return Items.Keys.Any(item => item is T);
        }
        public List<T> GetItemsByType<T>()
        {
            return Items.Keys.OfType<T>().ToList();
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
