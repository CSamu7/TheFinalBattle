namespace TheFinalBattle
{
    public record Item(int ID, string Name, string Description);
    public record Gear(int ID, string Name, string Description, IAttack SpecialAttack) : Item(ID, Name, Description);
    public record Potion(int ID, string Name, string Description, IPotion Effect) : Item(ID, Name, Description);
    public record HealthPotion() : Potion(1,"Health Potion", "Heal 10HP", new Heal(10));
    public record Sword(): Gear(2, "Sword", "Contains a slash attack!", new Slash());
    public record Dagger() : Gear(3, "Dagger", "Contains a sta attack!", new Stab());
}
