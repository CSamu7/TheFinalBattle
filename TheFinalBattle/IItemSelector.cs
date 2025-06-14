namespace TheFinalBattle
{
    public interface IItemSelector
    {
        IEntityCommand? GetItem();
        Item? SelectItem();
    }
    public class ItemSelectorAI : IItemSelector
    {
        private readonly Entity _entity;
        private readonly Battle _battle;
        public ItemSelectorAI(Entity entity, Battle battle) { 
            _entity = entity;
            _battle = battle;
        }
        public IEntityCommand? GetItem()
        {
            Item? selectedItem = SelectItem();

            if (selectedItem == null) return null;

            return new UseItem(selectedItem, _battle);
        }
        public Item? SelectItem()
        {
            Random rnd = new Random();
            double rndNumber = rnd.NextDouble();

            List<Item> items = _battle.GetPartyFor(_entity).Items;

            if (items.Count == 0) return null;

            if (_entity.HP < (_entity.MaxHP / 2) && rndNumber < .25)
            {
                return items.Find(item => item.Type == Type.Health);
            }

            return null;
        }
    }
}
