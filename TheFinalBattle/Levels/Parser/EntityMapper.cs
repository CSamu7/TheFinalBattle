using TheFinalBattle.Items;
using TheFinalBattle.Levels.DTO;
using TheFinalBattle.PlayableClasses;
using TheFinalBattle.UI;

namespace TheFinalBattle.Levels.Parser
{
    public class EntityMapper : IMapper<EntityDTO, Entity>
    {
        private readonly EntitiesList entities = new();
        public MappingResult<Entity> Map(EntityDTO entity)
        {
            IDefensiveModifier? defensiveModifier =
                entity.IdDefensiveModifier is not null ? GetDefensiveModifier(entity.IdDefensiveModifier.Value) : null;

            Gear? gear1 = entity.IdGear is not null ? GetGear(entity.IdGear.Value) : null;

            Entity? enemy = entities.GetByID(entity.Id);

            if (enemy is null) Errors.Add(new($"Entity #{entity.Id} doesn't exist", ErrorType.Error));

            return new MappingResult<Entity>(enemy, Errors);
        }
        private Gear? GetGear(int id)
        {
            ItemList list = new();
            Gear? gear = (Gear?)list.GetByID(id);

            if (gear is null)
                Errors.Add(new($"Gear #{id} doesn't exist", ErrorType.Warn));

            return gear;
        }
        private IDefensiveModifier? GetDefensiveModifier(int id)
        {
            DefensiveModifierList list = new();

            IDefensiveModifier? modifier = list.GetByID(id);

            if (modifier is null)
                Errors.Add(new($"Defensive modifier #{id} doesn't exist", ErrorType.Warn));

            return modifier;
        }
    }
}
