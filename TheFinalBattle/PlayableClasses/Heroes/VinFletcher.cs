using TheFinalBattle.Items;
using TheFinalBattle.Attacks;

namespace TheFinalBattle.PlayableClasses.Heroes
{
    public class VinFletcher : Entity
    {
        public override string Name { get; init; } = "Vin";
        public override int MaxHP { get; init; } = 15;
        public override IAttack StandardAttack { get; init; } = new Punch();
        public VinFletcher()
        {
            Gear = new VinBow();
        }
    }
}
