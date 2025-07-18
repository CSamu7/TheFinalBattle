using Utils;

namespace TheFinalBattle
{
    public interface IUseItem
    {
        public void Use(Entity entity);
    }
    public class UseItemCommand : IEntityCommand
    {
        private Item _item;
        private Inventory _inventory;
        public override string ToString()
        {
            return "Use item";
        }
        public UseItemCommand(Item item, Inventory inventory)
        {
            _item = item;
            _inventory = inventory;
        }
        public void Execute(Entity entity)
        {
            if(_item is Potion) new DrinkPotion((Potion) _item, _inventory).Use(entity);
            if(_item is Gear) new EquipGear((Gear) _item, _inventory).Use(entity);   
        }
    }
    public class DrinkPotion : IUseItem
    {
        private Potion _potion;
        private Inventory _inventory;
        public DrinkPotion(Potion item, Inventory inventory) {
            _potion = item;
            _inventory = inventory;
        }
        public void Use(Entity entity)
        {
            Console.WriteLine($"{entity.Name} has used {_potion.Name}");
            _potion.Effect.Consume(entity);
            DisplayItemMessage(entity.Name);
            _inventory.RemoveItem(_potion);
        }
        private void DisplayItemMessage(string name)
        {
            string message = _potion.Effect switch
            {
                Heal => $"{name} feels more healthy!",
                _ => $"{name} feels something?"
            };

            ConsoleUtils.WriteLine(message, ConsoleColor.Green);
        }
    }
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
            if(entity.Gear is null)
            {
                entity.Gear = _gear;
                _inventory.RemoveItem(_gear);
            } else
            {
                _inventory.RemoveItem(_gear);
                _inventory.AddItem(entity.Gear);
                entity.Gear = _gear;
            }

            Console.WriteLine($"{entity.Name} has equipped with {_gear.Name}");
        }
    }
}
