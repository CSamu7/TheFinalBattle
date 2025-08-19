using TheFinalBattle.Effects;
using TheFinalBattle.Items;
using TheFinalBattle.PlayableClasses;
using TheFinalBattle.PlayerCommands;

namespace TheFinalBattle.PartyControl
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
      
                if (probability < .25 && entity.HP < entity.MaxHP / 2 && inventory.HasItem<Potion>())
                {
                    List<Potion> potions = inventory.GetItemsByType<Potion>();
                    
                    if(potions.Any(potion => potion.Effect is Heal))
                    {
                        return new UseItem(potions[0], inventory);
                    }
                }

                if (probability < .50 && entity.Gear is null && inventory.HasItem<Gear>())
                {
                    List<Gear> gears = inventory.GetItemsByType<Gear>();
                    return new UseItem(gears[0], inventory);
                }

                if (entity.Gear is not null) 
                    return new Attack(entity.Gear.SpecialAttack, enemies.Members[0]);

                return new Attack(entity.StandardAttack, enemies.Members[0]);
            }
        }
    }
}
