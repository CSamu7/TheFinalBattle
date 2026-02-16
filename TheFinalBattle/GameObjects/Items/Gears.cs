using TheFinalBattle.GameObjects.Attacks;

namespace TheFinalBattle.GameObjects.Items
{
    public record Debugger() : Gear(2, "Lumina Saber", "Step Over, Continue", new CannonOfConsolas())
    {
        public override string ToString() => base.ToString();
    }
    public record GlassKnife() : Gear(5, "Glass Knife", "An old knife", new Slash())
    {
        public override string ToString() => base.ToString();
    }
    public record MeteorStaff() : Gear(6, "Meteor Staff", "What's that bright thing in the sky?", new Meteors())
    {
        public override string ToString() => base.ToString();
    }

}
