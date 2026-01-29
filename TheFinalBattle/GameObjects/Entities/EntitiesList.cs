using TheFinalBattle.GameObjects.Entities.Enemies;
using TheFinalBattle.GameObjects.Entities.Heroes;
using TheFinalBattle.GameObjects.Items;

namespace TheFinalBattle.GameObjects.Entities
{
    public class EntitiesList : IGameObjectList<Entity>
    {
        private readonly List<Entity> _entities = [
            new Pixie(),
            new JackFrost(),
            new Mara(),
            new Mothman(),
            new Vin() ,
            new Yosuke(),
            new Akechi() ,
            new WealthHand(),
            new Reaper()
        ];
        public Entity? GetByID(int id) => _entities.Where(entity => entity.Id == id).FirstOrDefault();
    }
}
