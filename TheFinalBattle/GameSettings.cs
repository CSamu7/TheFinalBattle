using TheFinalBattle.Generators;
using TheFinalBattle.PartyControl;

namespace TheFinalBattle
{
    public class GameSettings(PartySettings partyConfiguration, List<Level> levels)
    {
        public PartySettings PartySettings { get; set; } = partyConfiguration;
        public List<Level> Levels { get; } = levels;
    }
    public class PartySettings(IPartyControl heroePartyAI, IPartyControl enemyPartyAI)
    {
        public IPartyControl HeroePartyAI { get; set; } = heroePartyAI;
        public IPartyControl EnemyPartyAI { get; set; } = enemyPartyAI;
    }
}
