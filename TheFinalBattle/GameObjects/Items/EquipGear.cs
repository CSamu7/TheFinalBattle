using TheFinalBattle.GameObjects.Entities;

namespace TheFinalBattle.GameObjects.Items
{
    public class EquipGear : IUseItemCommand
    {
        private Inventory _inventory;
        private Gear _gear;
        public EquipGear(Gear gear, Inventory inventory)
        {
            _gear = gear;
            _inventory = inventory;
        }
        public void Use(Entity entity)
        {
            _inventory.RemoveItem(_gear);

            if (entity.Gear is not null)
                _inventory.AddItem(entity.Gear);

            entity.Gear = _gear;

            Console.WriteLine($"{entity.Name} has equipped with {_gear.Name}");
        }
    }
}
