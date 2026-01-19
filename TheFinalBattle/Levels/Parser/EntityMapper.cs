using TheFinalBattle.Items;
using TheFinalBattle.Levels.DTO;
using TheFinalBattle.PlayableClasses;
using TheFinalBattle.UI;

namespace TheFinalBattle.Levels.Parser
{
    public class EntityMapper : AbstractMapper<EntityDTO, Entity?>
    {
        private readonly EntitiesList entities = new();
        public override List<MappingError> Errors { get; protected set; } = [];
        public override Entity? Map(EntityDTO entity)
        {
            //FIX: No me parece buena idea poner en cada Mapper que los errores se restablezcan.
            Errors = [];

            IDefensiveModifier? defensiveModifier =
                entity.IdDefensiveModifier is not null ? GetDefensiveModifier(entity.IdDefensiveModifier.Value) : null;

            Gear? gear1 = entity.IdGear is not null ? GetGear(entity.IdGear.Value) : null;

            Entity? enemy = entities.GetByID(entity.Id);

            if (enemy is null) Errors.Add(new($"Entity #{entity.Id} doesn't exist", ErrorType.Error));

            return enemy;
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
