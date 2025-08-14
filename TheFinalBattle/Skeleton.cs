namespace TheFinalBattle
{
    public class Skeleton : Entity
    {
        public Skeleton() {
            StandardAttack = new BoneCrunch();
            Name = "SKELETON";
            MaxHP = 5;
            HP = MaxHP;
        }
        public Skeleton(Gear gear) : this()
        {
            Gear = gear;
        }
    }

    public class StoneAmarok : Entity
    {
        public StoneAmarok()
        {
            StandardAttack = new Bite();
            Name = "STONE AMAROK";
            MaxHP = 4;
            DefensiveModifier = new StoneArmor();
            HP = MaxHP;
        }
    }
    public class TheUncodedOne : Entity
    {
        public TheUncodedOne()
        {
            StandardAttack = new Unraveling();
            Name = "The Uncoded One";
            MaxHP = 15;
            HP = MaxHP;
        }
    }
}
