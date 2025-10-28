
using TheFinalBattle.Attacks;
using TheFinalBattle.Effects;

namespace TheFinalBattle.Items
{
    public record Item(string Name, string Description);
    public record Potion(string Name, string Description, IEffect Effect)
    : Item(Name, Description);
    public record Gear(string Name, string Description, IAttack SpecialAttack)
        : Item(Name, Description);

    //ITEMS
    public record Medicine() : Potion("Medicine", "Heal 10HP", new Heal(10));
    public record LuminaSaber() : Gear
    ("Lumina Saber", "A glimmering saber", new BladedRunners());
    public record Misericorde() : Gear
        ("Misericorde", "A mercy stroke!", new Bufu());
    public record KolossSword() : Gear
        ("Koloss Sword", "A heavy sword", new Push());
    public record GlassKnife() : Gear("Glass Knife", "", new Slash());
    public record Gun() : Gear("Gun", "", new QuickShot());
    public record ShortGun() : Gear("Short Gun", "", new PowerfulShot());
    public class ItemsList
    {
        private readonly Dictionary<int, Item> _items = new Dictionary<int, Item>()
        {
            {1, new Medicine() },
            {2, new LuminaSaber()},
            {3, new Misericorde() },
            {4, new KolossSword()},
            {5, new Gun() },
            {6, new GlassKnife() },
            {7, new ShortGun() }
        };

        public int GetID(Item item)
        {
            var keyValue = _items.Where(itm => item == itm.Value).Single();
            return keyValue.Key;
        }
        public Item GetByName(string name) => 
            _items.Where(item => item.Value.Name.ToLower() == name.ToLower()).First().Value;
    }
}
