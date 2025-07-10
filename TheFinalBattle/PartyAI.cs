namespace TheFinalBattle
{
    public class PartyAI : IPartyControl
    {
        private Random rnd = new Random();
        public IEntityCommand SelectAction(Entity entity, Battle battle)
        {
            Party party = battle.GetPartyFor(entity);
            Party enemies = battle.GetEnemyPartyFor(entity);

            Inventory inventory = party.Inventory;

            while (true)
            {
                double probability = rnd.NextDouble();

                if (probability < .01) return new DoNothing();

                //No checa realmente si hay pociones de salud, solo si hay pociones.
                //LINQ method.
                if (probability < .25 && entity.HP < entity.MaxHP / 2 && inventory.HasItem(ItemType.Potion))
                {
                    List<Item> potions = inventory.GetItemsByType(ItemType.Potion);
                    return new UseItemCommand(potions[0], inventory);
                }
                //LINQ method.
                if (probability < .50 && entity.Gear is null && party.Inventory.HasItem(ItemType.Gear))
                {
                    List<Item> gears = inventory.GetItemsByType(ItemType.Gear);
                    return new UseItemCommand(gears[0], inventory);
                }

                if (entity.Gear is not null) 
                    return new AttackCommand(entity.Gear.SpecialAttack, enemies.Members[0]);

                return new AttackCommand(entity.StandardAttack, enemies.Members[0]);
            }
        }
    }
}
