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
    public class LevelMapper : AbstractMapper<LevelDTO, Level?>
    {
        public override List<MappingError> Errors { get; protected set; } = [];
        private readonly PartyMapper _partyMapper = new();
        private readonly ItemAmountMapper _itemAmountMapper = new();
        public override Level? Map(LevelDTO rawLevel)
        {
            Errors = [];

            List<ItemAmount> rewards =rawLevel.Rewards
                .Select(rew => _itemAmountMapper.Map(rew))
                .OfType<ItemAmount>()   
                .ToList();

            Party party = _partyMapper.Map(rawLevel.PartyEnemy);

            Errors.AddRange(_partyMapper.Errors);
            Errors.AddRange(_itemAmountMapper.Errors);

            if (party.Members.Count == 0)
            {
                Errors.Add(new("This level doesn't have valid enemies. Omitting level...", ErrorType.Error));
                return null;
            }

            return new Level(party, rewards);
        }
    }
}
