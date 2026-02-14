using TheFinalBattle.GameObjects.Entities.Heroes;

namespace TheFinalBattle.Tests
{
    public class EntityTests
    {
        [Fact]
        public void Hp_is_0_when_hp_gets_under_zero()
        {
            Vin entity = new Vin();

            entity.HP -= 20;

            Assert.Equal(0, entity.HP);
        }
        [Fact]
        public void Hp_is_max_hp_when_hp_overpass_max_hp()
        {
            Vin entity = new Vin();

            entity.HP += 20;

            Assert.Equal(15, entity.HP);
        }
    }
}
