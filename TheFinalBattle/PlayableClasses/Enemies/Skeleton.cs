using TheFinalBattle.Attacks;
using TheFinalBattle.Items;

namespace TheFinalBattle.PlayableClasses.Enemies
{
    public class Skeleton : Entity
    {
        public Skeleton() {
            Name = "SKELETON";
            StandardAttack = new BoneCrunch();
            MaxHP = 5;
            HP = MaxHP;
        }
        public Skeleton(Gear gear) : this()
        {
            Gear = gear;
        }
    }
}
