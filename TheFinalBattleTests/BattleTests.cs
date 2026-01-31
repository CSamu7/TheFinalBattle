using TheFinalBattle.GameObjects.Entities.Enemies;

namespace TheFinalBattle.Tests
{
    public class BattleTests
    {
        Battle _battle;
        Party _heroes;
        Party _enemies;
        public BattleTests()
        {
            _heroes = new Party(new Akechi(), new Akechi());
            _enemies = new Party(new Mothman(), new Mothman());

            _battle = new Battle(_heroes, _enemies);
        }
        [Fact]
        public void GetPartyFor_HeroeEntity_ReturnsHeroeParty()
        {
            Party party = _battle.GetPartyFor(_heroes.Members[0]);

            Assert.Same(_heroes, party);
         }
    }
}
