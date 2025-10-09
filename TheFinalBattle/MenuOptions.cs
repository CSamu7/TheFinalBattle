using TheFinalBattle.PlayerCommands;
using TheFinalBattle.Interface;
using TheFinalBattle.PlayableClasses;
using TheFinalBattle.Attacks;
using TheFinalBattle.Items;

namespace TheFinalBattle
{
    public class MenuOptions
    {
        private Entity _entity;
        public MenuOptions(Entity entity)
        {
            _entity = entity;
        }
        public List<MenuItemAction<Func<IEntityCommand?>>> GetActions(Battle battle)
        {
            Inventory inventory = battle.GetPartyFor(_entity).Inventory;
            Party enemies = battle.GetEnemyPartyFor(_entity);

            return new List<MenuItemAction<Func<IEntityCommand?>>>
            {
                new("Do nothing", true, () => new DoNothing()),
                new("Attack", true, new AttackSubmenu(enemies, _entity).BuildCommand),
                new("Use item", inventory.Items.Count > 0, new ItemSubmenu(inventory, _entity).BuildCommand),
                new("Remove gear", _entity.Gear is not null, () => new RemoveGear(battle))
            };
        }
        public List<MenuItemAction<Item>> GetItems(Inventory inventory)
        {
            List<MenuItemAction<Item>> optionItems = new();

            foreach (SlotInventory slot in inventory.Items)
            {
                optionItems.Add(
                    new MenuItemAction<Item>($"{slot.Item.Name} x{slot.Amount}", true, slot.Item));
            }

            return optionItems;
        }
        public List<MenuItemAction<IAttack>> GetAttacks()
        {
            return new List<MenuItemAction<IAttack>>
            {
                new MenuItemAction<IAttack>($"Standard Attack: {_entity.StandardAttack.Name}",
                    true, _entity.StandardAttack),
                new MenuItemAction<IAttack>($"Special Attack: {_entity.Gear?.SpecialAttack.Name ?? "????"}",
                    _entity.Gear is not null, _entity.Gear?.SpecialAttack)
            };
        }
        public List<MenuItemAction<Entity>> GetEnemies(Party enemyParty)
        {
            var enemies = new List<MenuItemAction<Entity>>();

            foreach (Entity enemy in enemyParty.Members)
            {
                enemies.Add(new MenuItemAction<Entity>($"{enemy.Name} {enemy.HP}/{enemy.MaxHP}", true, enemy));
            }

            return enemies;
        }
    }
    public record MenuItemAction<T>(string Text, bool IsAvailable, T? Action);
    public enum MenuState { BackPrevMenu, InvalidInput, ValidItem }
}
