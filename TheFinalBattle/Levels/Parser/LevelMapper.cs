using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalBattle.Generators;
using TheFinalBattle.Levels.DTO;
using TheFinalBattle.UI;

namespace TheFinalBattle.Levels.Parser
{
    public class LevelMapper : IMapper<LevelDTO, Level>
    {
        private readonly PartyMapper _partyMapper = new();
        private readonly ItemAmountMapper _itemAmountMapper = new();
        public MappingResult<Level> Map(LevelDTO rawLevel)
        {
            List<MappingAlert> alerts = [];

            List<ItemAmount> rewards = rawLevel.Rewards
                .Select(rew => _itemAmountMapper.Map(rew).MappedObject)
                .OfType<ItemAmount>()   
                .ToList();

            MappingResult<Party> party = _partyMapper.Map(rawLevel.PartyEnemy);

            errors.AddRange(party.Errors);

            if (party.MappedObject?.Members.Count == 0)
                errors.Add(new("This level doesn't have valid enemies. Omitting level...", ErrorType.Error));

            return new MappingResult<Level>(
                new Level(party.MappedObject, rewards),
                errors
            );
        }
    }
}
