using TheFinalBattle.Attacks;

namespace TheFinalBattle.PlayableClasses.Enemies
{
    public class TheUncodedOne : Entity
    {
        public TheUncodedOne()
        {
            Name = "The Uncoded One";
            StandardAttack = new Unraveling();
            MaxHP = 15;
            HP = MaxHP;
        }
    }
}

