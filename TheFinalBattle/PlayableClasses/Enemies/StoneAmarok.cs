using TheFinalBattle.Attacks;
using TheFinalBattle.Items;

namespace TheFinalBattle.PlayableClasses.Enemies
{
    public class StoneAmarok : Entity
    {
        public override string Name { get; init; } = "Stone Amarok";
        public override int MaxHP { get; init; } = 4;
        public override IAttack StandardAttack { get; init; } = new Bite();
        public StoneAmarok() 
        {
            DefensiveModifier = new StoneArmor();
        }
    }
}
