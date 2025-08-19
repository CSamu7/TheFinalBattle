using TheFinalBattle.Attacks;

namespace TheFinalBattle.Items
{
    public record Gear(int ID, string Name, string Description, IAttack SpecialAttack) : Item(ID, Name, Description);
    public record Sword() : Gear(2, "Sword", "Contains a slash attack!", new Slash());
    public record Dagger() : Gear(3, "Dagger", "Contains a stab attack!", new Stab());
    public record VinBow() : Gear(4, "Vin's Bow", "Quick shot attack", new QuickShot());
}
