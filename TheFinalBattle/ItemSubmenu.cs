using Utils;

namespace TheFinalBattle
{
    public class ItemSubmenu : IItemSelector
    {
        private readonly Entity _entity;
        private readonly Battle _battle;
        public ItemSubmenu(Entity entity, Battle battle) { 
            _entity = entity;
            _battle = battle;   
        }
        public IEntityCommand? GetItem()
        {
            Party party = _battle.GetPartyFor(_entity);
   
            DisplayMenu(party);
            Item? selectedItem = SelectItem();

            if (selectedItem is null) return null;

            return new UseItem(selectedItem, _battle);
        }
        public Item? SelectItem()
        {
            Party party = _battle.GetPartyFor(_entity);
            int itemIndex;

            do
            {
                Console.Write("Which item do you want to use? ");
                if(!int.TryParse(Console.ReadLine(), out itemIndex))
                {
                    ConsoleUtils.WriteLine("Enter a number...", ConsoleColor.Red);
                    continue;
                }
            }
            while (itemIndex > party.Items.Count + 1 || itemIndex <= 0);

            if (itemIndex == party.Items.Count + 1) return null;

            return party.Items.ElementAt(itemIndex - 1);
        }
        private void DisplayMenu(Party party)
        {
            Console.WriteLine("=========ITEMS========");

            for (int i = 0; i < party.Items.Count; i++)
            {
                Console.WriteLine($"* ({i + 1}) {party.Items[i].Name}");
            }

            Console.WriteLine($"* ({party.Items.Count + 1}) Back");
        }
    }
}
