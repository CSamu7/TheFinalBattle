namespace TheFinalBattle.Items
{
    public record Item(int ID, string Name, string Description);

    /*This class has a serious flaw:
        - I have to enter manually the items, so I could forget to add an item or duplicate items
     *Maybe a posible solution would be create a JSON that contains all the items and just create a class
      that load the JSON
    */

    //Right now I have few items so it wont give problems, but in the future should change.
    public class ItemList
    {
        public List<Item> Items { get; private set; } = new List<Item>
        {
            {new Medicine() },
            {new LuminaSaber()},
            {new Misericorde()},
            {new KolossSword()},
            {new GlassKnife()},
            {new Gun() },
            {new ShortGun() }
        };
        public Item GetItem(int id)
        {
            return Items.First(item => item.ID == id);
        }
    }
}
