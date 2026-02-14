using TheFinalBattle.GameObjects.Entities;
using TheFinalBattle.GameObjects.Items;
using TheFinalBattle.Parties;

namespace TheFinalBattle.PlayerCommands
{
    public class UseItem : IEntityCommand
    {
        private Item _item;
        private Inventory _inventory;
        public override string ToString()
        {
            return "Use item";
        }
        public UseItem(Item item, Inventory inventory)
        {
            _item = item;
            _inventory = inventory;
        }
        public void Execute(Entity entity)
        {
            if (_item is Potion) new DrinkPotion((Potion)_item, _inventory).Use(entity);
            if (_item is Gear) new EquipGear((Gear)_item, _inventory).Use(entity);
        }
    }
}
