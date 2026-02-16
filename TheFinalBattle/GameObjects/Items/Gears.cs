using TheFinalBattle.GameObjects.Attacks;

namespace TheFinalBattle.GameObjects.Items
{
    public record Debugger() : Gear(2, "Debugger", "Step Over, Continue", new CannonOfConsolas())
    {
        public override string ToString() => base.ToString();
    }
    public record GlassKnife() : Gear(3, "Glass Knife", "An old knife", new Slash())
    {
        public override string ToString() => base.ToString();
    }
    public record IceStaff() : Gear(4, "Ice Staff", "It contains an awful spell...", new SnowGrave())
    {
        public override string ToString() => base.ToString();
    }
}
