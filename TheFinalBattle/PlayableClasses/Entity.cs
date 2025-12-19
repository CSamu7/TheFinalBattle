using TheFinalBattle.Attacks;
using TheFinalBattle.Items;
using TheFinalBattle.PlayableClasses.Enemies;
using TheFinalBattle.PlayableClasses.Heroes;
using Utils;

namespace TheFinalBattle.PlayableClasses
{
    public abstract class Entity : IGameObject
    {
        public abstract int Id { get; init; }
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
    };
    public class EntitiesList : IObjectList<Entity>
    {
        public EntitiesList()
        {
            List<Entity> test = _entities.Distinct().ToList();
        }
        private readonly List<Entity> _entities = new List<Entity>
        {
            new Pixie(),
            new JackFrost(),
            new Mara(),
            new Mothman(),
            new Vin() ,
            new Yosuke(), 
            new Akechi() ,
            new WealthHand(), 
            new Reaper() 
        };
        public Entity? GetByID(int id) => _entities.Where(entity => entity.ID == id).FirstOrDefault(); 
    }
}
