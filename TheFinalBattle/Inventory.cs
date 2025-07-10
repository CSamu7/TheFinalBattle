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
        public List<Item> GetItemsByType(ItemType type)
        {
            return Items.Where(item => item.ItemType.Equals(type)).ToList();
        }
        public bool HasItem(ItemType type)
        {
            return Items.Any(item => item.ItemType.Equals(type));
        }
        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }
    }
}
