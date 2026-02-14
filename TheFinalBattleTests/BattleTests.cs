using TheFinalBattle.GameObjects.Entities.Enemies;

namespace TheFinalBattle.Tests
{
    public class BattleTests
    {
        [Fact]
        public void Get_Party_Of_Entity()
        {
            Party _heroes = new Party(new Akechi(), new Akechi());
            Party _enemies = new Party(new Mothman(), new Mothman());
            Battle _battle = new Battle(_heroes, _enemies);

            Party party = _battle.GetPartyFor(_heroes.Members[0]);

            Assert.Same(_heroes, party);
        }

        [Fact]
        public void Get_Enemy_Party_Of_Entity()
        {
            Party _heroes = new Party(new Akechi(), new Akechi());
            Party _enemies = new Party(new Mothman(), new Mothman());
            Battle _battle = new Battle(_heroes, _enemies);

            Party party = _battle.GetEnemyPartyFor(_heroes.Members[0]);

            Assert.Same(_enemies, party);
        }
    }
}
