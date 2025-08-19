using TheFinalBattle.Effects;

namespace TheFinalBattle.Items
{
    public record Potion(int ID, string Name, string Description, IEffect Effect) : Item(ID, Name, Description);
    public record HealthPotion() : Potion(1, "Health Potion", "Heal 10HP", new Heal(10));
}
