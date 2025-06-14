namespace TheFinalBattle
{
    public class MenuOptions
    {
        public List<MenuOption> GenerateMainOptions(Entity entity, Battle battle)
        {
            Party party = battle.GetPartyFor(entity);

            return new List<MenuOption>
            {
                new MenuOption("Do nothing", true),
                new MenuOption($"{entity.StandardAttack.ToString()} - Standard Attack", true),
                new MenuOption("Use item", party.Items.Count > 0)
            };
        }
        public List<MenuOption> GenerateItems(Entity entity, Party party)
        {
            List<MenuOption> optionItems = new List<MenuOption>();

            foreach (Item item in party.Items)
            {
                optionItems.Add(new MenuOption($"{item.Name}", true));
            }

            return optionItems;
        }
    }
    public record MenuOption(string Description, bool isAvailable);
}
