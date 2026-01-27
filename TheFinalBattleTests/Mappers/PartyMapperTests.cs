using TheFinalBattle.Levels.DTO;
using TheFinalBattle.Levels.Mappers;

namespace TheFinalBattle.Tests.Mappers
{
    public class PartyMapperTests
    {
        [Fact]
        public void Party_is_mapped_if_has_one_valid_entity()
        {
            PartyDTO partyDto = Helper.GetPartyDTO(2, 1);
            PartyMapper partyMapper = new PartyMapper();

            MappingResult<Party> result = partyMapper.Map(partyDto);
            
            Assert.True(result.IsValid);
            Assert.True(result.Result.Members.Count == 1);
        }
        [Fact]
        public void Party_is_not_mapped_if_all_entities_are_invalid()
        {
            PartyDTO partyDto = Helper.GetPartyDTO(2, 0);
            PartyMapper partyMapper = new PartyMapper();

            MappingResult<Party> result = partyMapper.Map(partyDto);

            Assert.False(result.IsValid);
            Assert.Throws<InvalidOperationException>(() => result.Result);
        }
    }
}
