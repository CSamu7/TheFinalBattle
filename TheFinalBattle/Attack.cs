namespace TheFinalBattle
{
    public interface IAttack
    {
        int CalculateDamage();
    }
    public class Punch : IAttack
    {
        public override string ToString()
        {
            return "Punch";
        }
        public int CalculateDamage()
        {
            return 1;
        }
    }
    public class BoneCrunch : IAttack
    {
        public override string ToString()
        {
            return "Bone Crunch";
        }
        public int CalculateDamage()
        {
            Random rnd = new Random();
            int damage = rnd.Next(0, 2);
            return damage;
        }
    }
    public class Unraveling : IAttack
    {
        public override string ToString()
        {
            return "Unraveling Attack";
        }
        public int CalculateDamage()
        {
            Random rnd = new Random();
            int damage = rnd.Next(0, 3);
            return damage;
        }
    }
    public class Slash : IAttack
    {
        public override string ToString()
        {
            return "Slash";
        }
        public int CalculateDamage()
        {
            return 2;
        }
    }
    public class Stab : IAttack
    {
        public override string ToString()
        {
            return "Stab";
        }
        public int CalculateDamage()
        {
            return 1;
        }
    }
}
