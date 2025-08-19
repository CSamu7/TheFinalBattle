using TheFinalBattle.Items;
using TheFinalBattle.Attacks;

namespace TheFinalBattle.PlayableClasses.Heroes
{
    public class VinFletcher : Entity
    {
        public VinFletcher()
        {
            Name = "Vin";
            MaxHP = 15;
            HP = MaxHP;
            StandardAttack = new Punch();
            Gear = new VinBow();
        }
    }
}
