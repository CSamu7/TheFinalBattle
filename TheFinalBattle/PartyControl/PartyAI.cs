using TheFinalBattle.Items;
using TheFinalBattle.PlayableClasses;
using TheFinalBattle.PlayerCommands;

namespace TheFinalBattle.PartyControl
{
    //Rework PartyAI
    public class PartyAI : IPartyControl
    {
        private Random _rnd = new Random();        
        public IEntityCommand SelectAction(Entity entity, Battle battle)
        {
            Inventory inventory = battle.GetPartyFor(entity).Inventory;
            Party enemies = battle.GetEnemyPartyFor(entity);
            IEntityCommand? command = null;

            while (command is null) { 
                double probability = _rnd.NextDouble();

                command = probability switch
                {
                    <= .01 => new DoNothing(),
                    <= .25 => SelectItem(inventory, entity),
                    _ => SelectAttack(enemies, entity)
                };
            }

            return command;
        }
        public IEntityCommand? SelectItem(Inventory inventory, Entity entity)
        {
            List<Potion> items = inventory.Items.Select(slot => slot.Item).OfType<Potion>().ToList();
            List<Gear> gears = inventory.Items.Select(slot => slot.Item).OfType<Gear>().ToList();

            if (entity.HP < entity.MaxHP / 2 && items.Count > 0)
            {
                return new UseItem(items[0], inventory);
            }

            if (entity.Gear is null && gears.Count > 0)
            {
                return new UseItem(gears[0], inventory);
            }

            return null;
        }
        public IEntityCommand SelectAttack(Party enemies, Entity entity)
        {
            if (entity.Gear is not null)
                return new Attack(entity.Gear.SpecialAttack, enemies.Members[0]);

            return new Attack(entity.StandardAttack, enemies.Members[0]);
        }
    }
}
