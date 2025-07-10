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
}
