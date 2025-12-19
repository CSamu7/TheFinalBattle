
using TheFinalBattle.Attacks;
using TheFinalBattle.Effects;

namespace TheFinalBattle.Items
{
    public interface IGameObject
    {
        public int Id { get; init; }
        public string Name { get; init; }
    }
    public record Item(int Id, string Name, string Description) : IGameObject;
    public record Potion(int Id, string Name, string Description, IEffect Effect)
    : Item(Id, Name, Description);
    public record Gear(int Id, string Name, string Description, IAttack SpecialAttack)
        : Item(Id, Name, Description);
      
    public record Medicine() : Potion(1, "Medicine", "Heal 10HP", new Heal(10));
    public record LuminaSaber() : Gear(2, "Lumina Saber", "A glimmering saber", new BladedRunners());
    public record Misericorde() : Gear(3, "Misericorde", "A mercy stroke!", new Bufu());
    public record KolossSword() : Gear(4, "Koloss Sword", "A heavy sword", new Push());
    public record GlassKnife() : Gear(5, "Glass Knife", "", new Slash());
    public record Gun() : Gear(6, "Gun", "", new QuickShot());
    public record ShortGun() : Gear(7, "Short Gun", "", new PowerfulShot());

    public interface IObjectList<T> where T : IGameObject
    {
        public T? GetByID(int ID);
    }
    public class ItemList : IObjectList <Item>
    {
        private List<Item> _items = new List<Item>()
        {
            new Medicine(),
            new LuminaSaber(),
            new Misericorde(),
            new KolossSword(),
            new GlassKnife(),
            new Gun(),
            new ShortGun()
        };
        public Item? GetByID(int id) => _items.Find(item => item.Id == id);
    }
}
