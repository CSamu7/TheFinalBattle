using TheFinalBattle.GameObjects.Attacks;
using TheFinalBattle.GameObjects.DefensiveModifiers;
using TheFinalBattle.GameObjects.Items;
using Utils;

namespace TheFinalBattle.GameObjects.Entities
{
    public abstract class Entity
    {
        private int _hp;
        public abstract int Id { get; init; }
        public abstract string Name { get; init; }
        public abstract int MaxHP { get; init; }
        public abstract IAttack StandardAttack { get; init; }
        public int HP
        {
            get => _hp;
            set
            {
                if (value <= 0)
                {
                    _hp = 0;
                } else if (value >= MaxHP)
                {
                    _hp = MaxHP;
                } else
                {
                    _hp = value;
                }
            }
        }
        public Gear? Gear { get; set; } = null;
        public AbstractAttackModifier? AttackModifier { get; set; } = null;
        public Entity()
        {
            _hp = MaxHP;
        }
        public Entity(int maxHP)
        {
            MaxHP = maxHP;
            _hp = maxHP;
        }
        public Gear? Kill()
        {
            if (Gear is not null)
            {
                Console.Write($"{Name} has dropped the gear: ");
                ConsoleUtils.WriteLine($"{Gear.Name}", ConsoleColor.Green);
                Thread.Sleep(1000);
                return Gear;
            }

            return null;
        }
        public override string ToString() => Name;
    };

}
