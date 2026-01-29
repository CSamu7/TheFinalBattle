using TheFinalBattle.GameObjects.DefensiveModifiers;
using TheFinalBattle.GameObjects.Entities;
using TheFinalBattle.GameObjects.Items;
using TheFinalBattle.Levels.DTO;
using TheFinalBattle.UI;

namespace TheFinalBattle.Levels.Mappers
{
    public class EntityMapper : IMapper<EntityDTO, Entity>
    {
        private readonly EntitiesList entities = new();
        private List<MappingAlert> _alerts = [];
        public MappingResult<Entity> Map(EntityDTO entity)
        {
            _alerts = [];

            AbstractDefensiveModifier? defensiveModifier =
                entity.IdDefensiveModifier is not null ? GetDefensiveModifier(entity.IdDefensiveModifier.Value) : null;

            Gear? gear1 = entity.IdGear is not null ? GetGear(entity.IdGear.Value) : null;

            Entity? enemy = entities.GetByID(entity.Id);

            if (enemy is null)
            {
                _alerts.Add(new($"Entity #{entity.Id} doesn't exist", AlertType.Error));
                return MappingResult<Entity>.Failure(_alerts);
            }

            return MappingResult<Entity>.Success(enemy, _alerts);
        }
        private Gear? GetGear(int id)
        {
            ItemList list = new();
            Gear? gear = (Gear?)list.GetByID(id);

            if (gear is null)
                _alerts.Add(new($"Gear #{id} doesn't exist", AlertType.Warn));

            return gear;
        }
        private AbstractDefensiveModifier? GetDefensiveModifier(int id)
        {
            DefensiveModifierList list = new();

            AbstractDefensiveModifier? modifier = list.GetByID(id);

            if (modifier is null)
                _alerts.Add(new($"Defensive modifier #{id} doesn't exist", AlertType.Warn));

            return modifier;
        }
    }
}
