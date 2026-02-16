using TheFinalBattle.GameObjects.Attacks;
using TheFinalBattle.GameObjects.Effects;

namespace TheFinalBattle.GameObjects.Items
{
    public record Item(int Id, string Name, string Description);
    public record Potion(int Id, string Name, string Description, IEffect Effect)
    : Item(Id, Name, Description)
    {
        public override string ToString() => Name;
    }
    public record Gear(int Id, string Name, string Description, Attack SpecialAttack)
        : Item(Id, Name, Description)
    {
        public override string ToString() => Name;
    }
    public record Medicine() : Potion(1, "Medicine", "Heal 10HP", new Heal(10))
    {
        public override string ToString() => base.ToString();
    }
    public interface IGameObjectList<T>
    {
        public T? GetByID(int ID);
    }
    public class ItemList : IGameObjectList<Item>
    {
        private readonly List<Item> _items = new List<Item>()
        {
            new Medicine(),
            new GlassKnife(),
            new MeteorStaff(),
        };
        public Item? GetByID(int id) => _items.Find(item => item.Id == id);
    }
}
