using TheFinalBattle.Attacks;
using TheFinalBattle.Items;

namespace TheFinalBattle.PlayableClasses.Enemies
{
    public class StoneAmarok : Entity
    {
        public StoneAmarok()
        {
            Name = "STONE AMAROK";
            StandardAttack = new Bite();
            DefensiveModifier = new StoneArmor();
            MaxHP = 4;
            HP = MaxHP;
        }
    }
}
