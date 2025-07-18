namespace TheFinalBattle
{
    public class PartyAI : IPartyControl
    {
        private Random rnd = new Random();
        public IEntityCommand SelectAction(Entity entity, Battle battle)
        {
            Inventory inventory = battle.GetPartyFor(entity).Inventory;
            Party enemies = battle.GetEnemyPartyFor(entity);

            double probability = rnd.NextDouble();
            
            while (true)
            {
                if (probability < .01) return new DoNothing();

                if (inventory.HasItem<Potion>())
                {
                    List<Potion> potions = inventory.GetItemsByType<Potion>();
                    bool isThereHealthPotions = potions.Any(potion => potion.Effect is Heal);

                    if (isThereHealthPotions && probability < .25 && entity.HP < entity.MaxHP / 2)
                    {
                        return new UseItemCommand(potions[0], inventory);
                    }
                }

                if (probability < .50 && entity.Gear is null && inventory.HasItem<Gear>())
                {
                    List<Gear> gears = inventory.GetItemsByType<Gear>();
                    return new UseItemCommand(gears[0], inventory);
                }

                if (entity.Gear is not null) 
                    return new AttackCommand(entity.Gear.SpecialAttack, enemies.Members[0]);

                return new AttackCommand(entity.StandardAttack, enemies.Members[0]);
            }
        }
    }
}
