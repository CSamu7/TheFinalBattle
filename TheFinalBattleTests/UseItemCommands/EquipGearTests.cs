using TheFinalBattle.GameObjects.Entities.Heroes;
using TheFinalBattle.GameObjects.Items;
using TheFinalBattle.Parties;

namespace TheFinalBattle.Tests.UseItemCommands
{
    public class EquipGearTests
    {
        [Fact]
        public void Equips_gear_and_remove_from_inventory()
        {
            Protagonist entity = new Protagonist("Test");
            entity.Gear = null;
            Gear gear = new TestGear();
            Inventory inventory = new Inventory();
            inventory.AddItem(gear);
            EquipGear sut = new EquipGear(gear, inventory);

            sut.Use(entity);

            Assert.Equal(entity.Gear, gear);
            Assert.Empty(inventory.Items);
        }
    }
}
