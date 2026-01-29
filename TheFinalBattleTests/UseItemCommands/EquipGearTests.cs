using TheFinalBattle.GameObjects.Entities.Heroes;
using TheFinalBattle.GameObjects.Items;

namespace TheFinalBattle.Tests.UseItemCommands
{
    public class EquipGearTests
    {
        [Fact]
        public void Equips_gear_and_remove_from_inventory()
        {
            Protagonist entity = new Protagonist("test");
            Gear gear = new KolossSword();
            Inventory inventory = new Inventory();
            inventory.AddItem(gear);

            EquipGear command = new EquipGear(gear, inventory);

            command.Use(entity);

            Assert.Equal(entity.Gear, gear);
            Assert.Empty(inventory.Items);
        }
    }
}
