using TheFinalBattle.Attacks;
using TheFinalBattle.PlayableClasses;

namespace TheFinalBattle.Interface
{
    public class AttacksSubmenu : MenuTemplate<IAttack>
    {
        protected override List<MenuItemAction<IAttack>> Options { get; set; }
        private Entity _entity;
        public AttacksSubmenu(Entity entity)
        {
            _entity = entity;

            MenuTitle = "=========CHOOSE YOUR ATTACK=========";
            InputText = "Enter your attack: ";
            Options = new MenuOptions(_entity).GetAttacks();
        }
        public IAttack? SelectAttack() => GetOption();
    }
}
