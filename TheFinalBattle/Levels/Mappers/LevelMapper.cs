using TheFinalBattle.Generators;
using TheFinalBattle.Levels.DTO;
using TheFinalBattle.Levels.Mappers;
using TheFinalBattle.UI;

namespace TheFinalBattle.Levels.Parser
{
    public class LevelMapper : IMapper<LevelDTO, Level>
    {
        private readonly PartyMapper _partyMapper = new();
        private readonly ItemAmountMapper _itemAmountMapper = new();
        private readonly MapperList mapper = new MapperList();
        public MappingResult<Level> Map(LevelDTO rawLevel)
        {
            List<MappingAlert> alerts = [];

            MappingResult<Party> party = _partyMapper.Map(rawLevel.PartyEnemy);
            (List<ItemAmount> items, List<MappingAlert> itemAlerts) = 
                mapper.MapItems(rawLevel.Rewards, _itemAmountMapper);

            alerts.AddRange(party.Alerts);
            alerts.AddRange(itemAlerts);

            if (!party.IsValid)
            {
                alerts.Add(new("This level doesn't have valid enemies. Omitting level...", AlertType.Error));
                return MappingResult<Level>.Failure(alerts);
            } else
            {
                alerts.Add(new("This level can be created", AlertType.Info));
                return MappingResult<Level>.Success(new(party.Result, items), alerts);
            }
        }
    }
}
