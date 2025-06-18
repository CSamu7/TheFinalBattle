namespace TheFinalBattle
{
    public class PartyEnemyFactory
    {
        private Party _enemyParty;
        public PartyEnemyFactory(IPartyControl control)
        {
            _enemyParty = new Party(control);
            _enemyParty.Inventory.AddItem(new HealthPotion());
        }
        public Party? Create(int battleNumber)
        {
            List<Entity>? enemies = GetEnemies(battleNumber);
            if (enemies is null) return null;

            List<Item> items = GetItems(battleNumber);
            _enemyParty.AddMembers(enemies);

            foreach (Item item in items) {
                _enemyParty.Inventory.AddItem(item);
            }

            return _enemyParty;
        }
        private List<Item> GetItems(int battleNumber)
        {
            return battleNumber switch
            {
                1 => new List<Item> { new HealthPotion() },
                2 => new List<Item> { new Dagger(), new Dagger() },
            };
        }
        private List<Entity>? GetEnemies(int battleNumber)
        {
            return battleNumber switch
            {
                1 => new List<Entity> { new Skeleton(new Dagger()) },
                2 => new List<Entity> { new Skeleton(), new Skeleton() },
                3 => new List<Entity> { new Skeleton(), new TheUncodedOne() },
                _ => null
            };
        }
    }
}
