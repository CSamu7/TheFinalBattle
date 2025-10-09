
using TheFinalBattle.Attacks;
using TheFinalBattle.Effects;

namespace TheFinalBattle.Items
{
    public record Item(int ID, string Name, string Description);
    public record Medicine() : Potion(1, "Medicine", "Heal 10HP", new Heal(10));
    public record LuminaSaber() : Gear
    (2, "Lumina Saber", "A glimmering saber", new BladedRunners());
    public record Misericorde() : Gear
        (3, "Misericorde", "A mercy stroke!", new Bufu());
    public record KolossSword() : Gear
        (4, "Koloss Sword", "A heavy sword", new Push());
    public record GlassKnife() : Gear(5, "Glass Knife", "", new Slash());
    public record Gun() : Gear(6, "Gun", "", new QuickShot());
    public record ShortGun() : Gear(7, "Short Gun", "", new PowerfulShot());

}
