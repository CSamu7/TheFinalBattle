namespace TheFinalBattle.Items
{
    public record Item(int ID, string Name, string Description);
    public class ListItems
    {
        public List<Item> Items { get; private set; } = new List<Item>()
        {
            new HealthPotion(),
            new Sword(),
            new Dagger(),
        };
        public Item GetItemByID(int ID)
        {
          return Items.Where(item => item.ID == ID).Take(1).ToList()[0];
        }
    }
}
