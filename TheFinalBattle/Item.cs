namespace TheFinalBattle
{
    public record Item(int ID, string Name, string Description, ItemType ItemType);
    public record Gear(int ID, string Name, string Description, IAttack SpecialAttack) : Item(ID, Name, Description, ItemType.Gear);
    public record Potion(int ID, string Name, string Description, IPotion Effect, PotionType PotionType) : Item(ID, Name, Description, ItemType.Potion);
    public interface IItem;
    //Retrieve a item through an Enum?
    public enum ItemType { Potion, Gear }
    public enum PotionType { Health, Defense, XP, Damage}
    public record HealthPotion() : Potion(1,"Health Potion", "Heal 10HP", new Heal(), PotionType.Health);
    public record Sword(): Gear(2, "Sword", "Contains a slash attack!", new Slash());
    public record Dagger() : Gear(3, "Dagger", "Contains a sta attack!", new Stab());
}
