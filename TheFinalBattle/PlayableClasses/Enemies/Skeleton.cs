using TheFinalBattle.Attacks;
using TheFinalBattle.Items;

namespace TheFinalBattle.PlayableClasses.Enemies
{
    public class Skeleton : Entity
    {
        public override string Name { get; init; } = "Skeleton";
        public override int MaxHP { get; init; } = 5;
        public override IAttack StandardAttack { get; init; } = new BoneCrunch();
        public Skeleton() { }
        //Muy poco reusable, probablemente tendremos que hacer una fabrica...
        public Skeleton(Gear gear)
        {
            Gear = gear;
        }
    }
}
