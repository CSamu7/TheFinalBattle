namespace TheFinalBattle
{
    public record ItemInventory(Item item, int amount);
    public class Inventory
    {
        public Dictionary<int, int> Items { get; private set; } = new Dictionary<int, int>();
        private ListItems _items = new ListItems();
        public Inventory() { }
        public void AddItem(int ID, int amount = 1)
        {
            if (!_items.Items.Any(item => item.ID == ID))
            {
                throw new ArgumentException("Item doesn't exists");
            }

            if (Items.ContainsKey(ID))
            {
                Items[ID] += amount;
            } else
            {
                Items.Add(ID, amount);
            }
        }
        public void TransferInventory(Inventory inventory)
        {
            foreach (KeyValuePair<int, int> invItem in Items)
            {
                inventory.AddItem(invItem.Key, invItem.Value);
                RemoveItem(invItem.Key, invItem.Value);
            }
        }
        public bool HasItem<T>()
        {
            return Items.Keys.Any(item => item is T);
        }
        public List<T> GetItemsByType<T>()
        {
            return Items.Keys.OfType<T>().ToList();
        }
        public void RemoveItem(int ID, int amount)
        {
            if (Items.ContainsKey(ID))
            {
                if (Items[ID] <= amount)
                {
                    Items.Remove(ID);
                } else
                {
                    Items[ID] -= amount;
                }
            }
        }
    }
}
