using TheFinalBattle.GameObjects.Attacks;
using TheFinalBattle.GameObjects.Entities;

namespace TheFinalBattle.UI
{
    public class AttacksSubmenu : MenuTemplate<Attack>
    {
        protected override List<MenuItemAction<Attack>> Options { get; set; }
        private Entity _entity;
        public AttacksSubmenu(Entity entity)
        {
            _entity = entity;

            MenuTitle = "=========CHOOSE YOUR ATTACK=========";
            InputText = "Enter your attack: ";
            Options = new MenuOptions(_entity).GetAttacks();
        }
        public Attack? SelectAttack() => GetOption();
    }
}
