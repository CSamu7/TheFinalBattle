using TheFinalBattle.GameObjects.Entities;
using TheFinalBattle.PlayerCommands;

namespace TheFinalBattle.UI
{
    public class MainMenu : MenuTemplate<Func<IEntityCommand?>>
    {
        protected override List<MenuItemAction<Func<IEntityCommand?>>> Options { get; set; }
        public MainMenu(Entity entity, Battle battle) {
            MenuTitle = "=======YOUR ACTIONS=======";
            InputText = "What do you want to do? ";
            IsSubmenu = false;
            Options = new MenuOptions(entity).GetActions(battle);
        }
    }
}
