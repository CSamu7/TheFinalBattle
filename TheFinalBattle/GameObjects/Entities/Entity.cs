using TheFinalBattle.GameObjects.DefensiveModifiers;
using TheFinalBattle.GameObjects.Items;
using TheFinalBattle.PlayerCommands.Attacks;
using Utils;

namespace TheFinalBattle.GameObjects.Entities
{
    public abstract class Entity
    {
        public abstract int Id { get; init; }
        public abstract string Name { get; init; }
        public abstract int MaxHP { get; init; }
        public abstract IAttack StandardAttack { get; init; }
        public int HP { get; set; }
        public Gear? Gear { get; set; } = null;
        public AbstractDefensiveModifier? DefensiveModifier { get; set; } = null;
        public Entity()
        {
            HP = MaxHP;
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
