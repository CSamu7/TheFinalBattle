namespace TheFinalBattle
{
    public class Inventory
    {
        public List<Item> Items { get; private set; } = new List<Item>();
        public Inventory() { }
        public void AddItem(Item item, int amount = 1)
        {
            for (int i = 0; i < amount; i++)
            {
                Items.Add(item);
            }
        }
        public Item GetItemAt(int index)
        {
            return Items.ElementAt(index);
        }
        public bool HasItem<T>() where T : Item
        {
            return Items.Any(item => item is T);
        }
        public List<T> GetItemsByType<T>() where T : Item
        {
            return Items.OfType<T>().ToList();
        }
        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }
    }
}
