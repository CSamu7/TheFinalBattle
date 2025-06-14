namespace TheFinalBattle
{
    public interface IItem
    {
        void Use(Entity entity);
    }
    public class Heal : IItem
    {
        public void Use(Entity entity)
        {
            entity.HP += 10;
                
            if (entity.HP > entity.MaxHP) entity.HP = entity.MaxHP;
        }
    }
    //Retrieve a item through an Enum?
    public enum Type { Health, Defense, XP, Damage}
    public record Item(int ID, string Name, string Description, IItem Effect, Type Type );
    public record HealthPotion() : Item(1,"Health Potion", "Heal 10HP", new Heal(), Type.Health);
}
