using TheFinalBattle.Attacks;
using TheFinalBattle.Items;

namespace TheFinalBattle.PlayableClasses
{
    public abstract class Entity
    {
        public abstract string Name { get; init; }
        public abstract int MaxHP { get; init; }
        public abstract IAttack StandardAttack { get; init; }
        public int HP { get; set; } 
        public Gear? Gear { get; set; } = null;
        public IDefensiveModifier? DefensiveModifier { get; init; } = null;
        public Entity()
        {
            HP = MaxHP;
        }
    }
}
