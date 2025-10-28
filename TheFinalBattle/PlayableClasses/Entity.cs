using TheFinalBattle.Attacks;
using TheFinalBattle.Items;
using TheFinalBattle.PlayableClasses.Enemies;
using TheFinalBattle.PlayableClasses.Heroes;

namespace TheFinalBattle.PlayableClasses
{
    public abstract class Entity
    {
        public abstract string Name { get; init; }
        public abstract int MaxHP { get; init; }
        public abstract IAttack StandardAttack { get; init; }
        public int HP { get; set; } 
        public Gear? Gear { get; set; } = null;
        public IDefensiveModifier? DefensiveModifier { get; set; } = null;
        public Entity()
        {
            HP = MaxHP;
        }
    };
    public static class EntitiesList
    {
        private static readonly List<Entity> _entities = new List<Entity>() {
            new Akechi(), new JackFrost(), new Mara(), new Mothman(),
            new Pixie(), new Reaper(), new WealthHand(), new Vin(), new Yosuke()
        };
        public static Entity GetEntityByName(string name)
        {
            return _entities.Where(entity => entity.Name == name).FirstOrDefault();  
        }
    }

}
