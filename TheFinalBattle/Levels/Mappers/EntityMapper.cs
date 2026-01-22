using TheFinalBattle.Items;
using TheFinalBattle.Levels.DTO;
using TheFinalBattle.Levels.Mappers;
using TheFinalBattle.PlayableClasses;
using TheFinalBattle.UI;

namespace TheFinalBattle.Levels.Parser
{
    public class EntityMapper : IMapper<EntityDTO, Entity>
    {
        private readonly EntitiesList entities = new();
        private List<MappingAlert> _alerts = [];
        public MappingResult<Entity> Map(EntityDTO entity)
        {
            _alerts = [];

            IDefensiveModifier? defensiveModifier =
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
        private IDefensiveModifier? GetDefensiveModifier(int id)
        {
            DefensiveModifierList list = new();

            IDefensiveModifier? modifier = list.GetByID(id);

            if (modifier is null)
                _alerts.Add(new($"Defensive modifier #{id} doesn't exist", AlertType.Warn));

            return modifier;
        }
    }
}
