using System.Collections.Generic;
using System.Text;
using TheFinalBattle.Levels.DTO;
using TheFinalBattle.PlayableClasses;
using TheFinalBattle.UI;

namespace TheFinalBattle.Levels.Parser
{
    internal class PartyMapper : IMapper<PartyDTO, Party>
    {
        private readonly EntityMapper _entityMapper = new();
        private readonly ItemAmountMapper _itemAmountMapper = new();
        private readonly MapperList _mapperlist = new();
        public MappingResult<Party> Map(PartyDTO party)
        {
            List<MappingAlert> Errors = [];

            (List<ItemAmount> items, List<MappingAlert> itemAlerts) = 
                _mapperlist.MapItems(party.Inventory, _itemAmountMapper);

            (List<Entity> entities, List<MappingAlert> entityAlerts) =
                _mapperlist.MapItems(party.Enemies, _entityMapper);

            Errors.AddRange(itemAlerts);
            Errors.AddRange(entityAlerts);

            return MappingResult<Party>.Success(
                new Party
                {
                    Inventory = new Inventory { Items = items },
                    Members = entities
                },
                Errors
            );
        }
    }
}
