using TheFinalBattle.Items;
using TheFinalBattle.PlayableClasses;
using TheFinalBattle.PlayerCommands;

namespace TheFinalBattle.Interface
{
    public class ItemSubmenu : MenuTemplate<Item>, ICommandCreation
    {
        protected override List<MenuItemAction<Item>> Options { get; set; }
        private Inventory _inventory;
        public ItemSubmenu(Inventory inventory, Entity entity) {
            _inventory = inventory;

            Options = new MenuOptions(entity).GetItems(_inventory);
            InputText = "Which item do you want to use? ";
            MenuTitle = "=========ITEMS=========";
        }
        public IEntityCommand? BuildCommand()
        {
            Item? item = GetOption();

            return item is null 
                ? null 
                : new UseItem(item, _inventory);
        }
    }
}
