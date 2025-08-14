namespace TheFinalBattle
{
    public class PartyEnemyFactory
    {
        private Party _enemyParty;
        public PartyEnemyFactory(IPartyControl control)
        {
            _enemyParty = new Party(control);
        }
        public Party? Create(int battleNumber)
        {
            List<Entity>? enemies = GenerateEnemies(battleNumber);
            if (enemies is null) return null;

            List<Item> items = GenerateInventory(battleNumber);
            _enemyParty.AddMembers(enemies);

            foreach (Item item in items) {
                _enemyParty.Inventory.AddItem(item.ID);
            }

            return _enemyParty;
        }
        private List<Item> GenerateInventory(int battleNumber)
        {
            return battleNumber switch
            {
                1 => new List<Item> { new HealthPotion() },
                2 => new List<Item> { new Dagger(), new Dagger() },
                _ => new()
            };
        }
        private List<Entity>? GenerateEnemies(int battleNumber)
        {
            return battleNumber switch
            {
                1 => new List<Entity> { new Skeleton(new Dagger()) },
                2 => new List<Entity> { new StoneAmarok(), new StoneAmarok() },
                3 => new List<Entity> { new Skeleton(), new Skeleton() },
                4 => new List<Entity> { new Skeleton(), new TheUncodedOne() },
                _ => null
            };
        }
    }
}
