namespace TheFinalBattle
{
    public class TrueProgrammer : Entity
    {
        public TrueProgrammer(string name)
        {
            StandardAttack = new Punch();
            Name = name;
            MaxHP = 25;
            HP = MaxHP;
            Gear = new Sword();
        }
    }

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
