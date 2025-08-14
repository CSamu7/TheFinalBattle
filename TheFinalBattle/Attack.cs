namespace TheFinalBattle
{
    public interface IAttack
    {
        public string Name { get; }
        AttackData CalculateAttack();
    }
    public class Punch : IAttack
    {
        public string Name { get; } = "Punch";
        public AttackData CalculateAttack()
        {
            return new AttackData(1);
        }
    }
    public class BoneCrunch : IAttack
    {
        public string Name { get; } = "Bone Crunch";
        public AttackData CalculateAttack()
        {
            Random rnd = new Random();
            int damage = rnd.Next(0, 2);
            return new AttackData(damage);
        }
    }
    public class Unraveling : IAttack
    {
        public string Name { get; } = "Unraveling";
        public AttackData CalculateAttack()
        {
            Random rnd = new Random();
            int damage = rnd.Next(0, 3);
            return new AttackData(damage);
        }
    }
    public class Bite : IAttack
    {
        public string Name { get; } = "Bite";
        public AttackData CalculateAttack()
        {
            return new AttackData(2);
        }
    }

    public class Slash : IAttack
    {
        public string Name { get; } = "Slash";
        public AttackData CalculateAttack()
        {
            return new AttackData(2);
        }
    }
    public class Stab : IAttack
    {
        public string Name { get; } = "Stab";
        public AttackData CalculateAttack()
        {
            return new AttackData(1);
        }
    }
    public class QuickShot : IAttack
    {
        public string Name { get; } = "QuickShot";
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
