namespace TheFinalBattle
{
    public interface IAttack
    {
        AttackData CalculateAttack();
    }
    public class Punch : IAttack
    {
        public override string ToString()
        {
            return "Punch";
        }
        public AttackData CalculateAttack()
        {
            return new AttackData(1);
        }
    }
    public class BoneCrunch : IAttack
    {
        public override string ToString()
        {
            return "Bone Crunch";
        }
        public AttackData CalculateAttack()
        {
            Random rnd = new Random();
            int damage = rnd.Next(0, 2);
            return new AttackData(damage);
        }
    }
    public class Unraveling : IAttack
    {
        public override string ToString()
        {
            return "Unraveling Attack";
        }
        public AttackData CalculateAttack()
        {
            Random rnd = new Random();
            int damage = rnd.Next(0, 3);
            return new AttackData(damage);
        }
    }
    public class Slash : IAttack
    {
        public override string ToString()
        {
            return "Slash";
        }
        public AttackData CalculateAttack()
        {
            return new AttackData(2);
        }
    }
    public class Stab : IAttack
    {
        public override string ToString()
        {
            return "Stab";
        }
        public AttackData CalculateAttack()
        {
            return new AttackData(1);
        }
    }

    public class QuickShot : IAttack
    {
        public override string ToString()
        {
            return "Quick shot";
        }

        public AttackData CalculateAttack()
        {
            return new AttackData(3, .5);
        }
    }

    /// <param name="success">0 = Absolute Failure, 1 = Success</param>
    public record AttackData(int Damage, double Success = 1);
}
