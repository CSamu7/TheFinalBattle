using TheFinalBattle.GameObjects.Effects;
using TheFinalBattle.GameObjects.Entities;
using TheFinalBattle.Parties;
using Utils;

namespace TheFinalBattle.GameObjects.Items
{
    public class DrinkPotion : IUseItemCommand
    {
        private Potion _potion;
        private Inventory _inventory;
        public DrinkPotion(Potion item, Inventory inventory)
        {
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
}
