using TheFinalBattle.Attacks;
using TheFinalBattle.Items;

namespace TheFinalBattle.PlayableClasses.Enemies
{
    public class JackFrost : Entity
    {
        public override string Name { get; init; } = "Jack Frost";
        public override int MaxHP { get; init; } = 8;
        public override IAttack StandardAttack { get; init; } = new Bufu();
        public JackFrost() 
        {
            DefensiveModifier = new StoneArmor();
        }
    }
}
