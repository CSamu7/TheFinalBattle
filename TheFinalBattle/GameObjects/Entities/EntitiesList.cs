using TheFinalBattle.GameObjects.Entities.Enemies;
using TheFinalBattle.GameObjects.Entities.Heroes;
using TheFinalBattle.GameObjects.Items;

namespace TheFinalBattle.GameObjects.Entities
{
    public class EntitiesList : IGameObjectList<Entity>
    {
        private readonly Dictionary<int, Entity> _entities = new Dictionary<int, Entity>()
        {
            {1, new Vin() },
            {2, new Skeleton() },
            {3, new Archer() },
            {4, new Fairy() },
            {5, new Undefined() },
            {6, new FireHog() },
            {7, new TheUncodedOne() }
        };
        public Entity? GetByID(int id) => _entities.GetValueOrDefault(id);
    }
}
