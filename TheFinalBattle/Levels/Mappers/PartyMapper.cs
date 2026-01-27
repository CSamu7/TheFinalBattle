using TheFinalBattle.Levels.DTO;
using TheFinalBattle.PlayableClasses;
using TheFinalBattle.UI;

namespace TheFinalBattle.Levels.Mappers
{
    public class PartyMapper : IMapper<PartyDTO, Party>
    {
        private readonly EntityMapper _entityMapper = new();
        private readonly ItemAmountMapper _itemAmountMapper = new();
        private readonly MapperList _mapperlist = new();
        public MappingResult<Party> Map(PartyDTO party)
        {
            List<MappingAlert> Alerts = [];

            (List<ItemAmount> items, List<MappingAlert> itemAlerts) =
                _mapperlist.MapItems(party.Inventory, _itemAmountMapper);

            (List<Entity> entities, List<MappingAlert> entityAlerts) =
                _mapperlist.MapItems(party.Enemies, _entityMapper);

            Alerts.AddRange(itemAlerts);
            Alerts.AddRange(entityAlerts);

            return entities.Count == 0
                ? MappingResult<Party>.Failure(Alerts)
                : MappingResult<Party>.Success(
                    new Party
                    {
                        Inventory = new Inventory { Items = items },
                        Members = entities
                    }, Alerts);
        }
    }
}
