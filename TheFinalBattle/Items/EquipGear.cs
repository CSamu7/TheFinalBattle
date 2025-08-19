using TheFinalBattle.PlayableClasses;

namespace TheFinalBattle.Items
{
    public class EquipGear : IUseItem
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
            if (entity.Gear is null)
            {
                entity.Gear = _gear;
                _inventory.RemoveItem(_gear.ID, 1);
            } else
            {
                _inventory.RemoveItem(_gear.ID, 1);
                _inventory.AddItem(entity.Gear.ID);
                entity.Gear = _gear;
            }

            Console.WriteLine($"{entity.Name} has equipped with {_gear.Name}");
        }
    }
}
