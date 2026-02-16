using TheFinalBattle.GameObjects.Attacks;

namespace TheFinalBattle.GameObjects.Items
{
    public record LuminaSaber() : Gear(2, "Lumina Saber", "A glimmering saber", new BladedRunners())
    {
        public override string ToString() => base.ToString();
    }
    public record Misericorde() : Gear(3, "Misericorde", "A mercy stroke!", new SnowStorm())
    {
        public override string ToString() => base.ToString();
    }
    public record KolossSword() : Gear(4, "Koloss Sword", "A heavy sword", new Push())
    {
        public override string ToString() => base.ToString();
    }
    public record GlassKnife() : Gear(5, "Glass Knife", "", new Slash())
    {
        public override string ToString() => base.ToString();
    }
    public record Gun() : Gear(6, "Gun", "", new QuickShot())
    {
        public override string ToString() => base.ToString();
    }
    public record ShortGun() : Gear(7, "Short Gun", "", new PowerfulShot())
    {
        public override string ToString() => base.ToString();
    }
}
