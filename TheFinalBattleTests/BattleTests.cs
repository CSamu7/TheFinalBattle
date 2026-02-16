using TheFinalBattle.GameObjects.Entities.Enemies;
using TheFinalBattle.Parties;

namespace TheFinalBattle.Tests
{
    public class BattleTests
    {
        [Fact]
        public void Get_Party_Of_Entity()
        {
            Party _heroes = new Party(new Skeleton(), new Skeleton());
            Party _enemies = new Party(new FireHog(), new FireHog());
            Battle _battle = new Battle(_heroes, _enemies);

            Party party = _battle.GetPartyFor(_heroes.Members[0]);

            Assert.Same(_heroes, party);
        }

        [Fact]
        public void Get_Enemy_Party_Of_Entity()
        {
            Party _heroes = new Party(new Skeleton(), new Skeleton());
            Party _enemies = new Party(new FireHog(), new FireHog());
            Battle _battle = new Battle(_heroes, _enemies);

            Party party = _battle.GetEnemyPartyFor(_heroes.Members[0]);

            Assert.Same(_enemies, party);
        }
    }
}
