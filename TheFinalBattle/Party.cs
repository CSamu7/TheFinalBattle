using TheFinalBattle.PlayableClasses;
using TheFinalBattle.PartyControl;
using Utils;
using TheFinalBattle.Items;

namespace TheFinalBattle
{
    public class Party
    {
        private readonly int _maxMembers = 3;
        public List<Entity> Members { get; private set; } = new List<Entity>();
        public Inventory Inventory { get; private set; } = new Inventory();
        public IPartyControl PartyControl { get; set; } 
        public Party(IPartyControl control)
        {
            PartyControl = control;
        }
        public Party(IPartyControl control, List<Entity> members)
        {
            PartyControl = control;
            Members = members.ToList();
        }
        public Party(IPartyControl control, List<Entity> members, List<Item> items)
        {
            PartyControl = control;
            Members = members.ToList();

            foreach (Item item in items)
            {
                Inventory.AddItem(item);
            }
        }
        public void RemoveMember(Entity entity)
        {
            Members.Remove(entity);
        }
        public bool AddMember(Entity member)
        {
            if (Members.Count > _maxMembers)
            {
                return false;
            }

            Members.Add(member);
            return true;
        }
        public void RemoveDeadMembers(Inventory enemyInventory)
        {
            List<Entity> deadMembers = Members.Where(member => member.HP <= 0).ToList();

            foreach (Entity entity in deadMembers)
            {
                if (entity.Gear is not null)
                {
                    Console.Write($"The enemy {entity.Name} has dropped the gear: ");
                    ConsoleUtils.WriteLine($"{entity.Gear.Name}", ConsoleColor.Green);
                    Thread.Sleep(1000);
                    enemyInventory.AddItem(entity.Gear);
                }

                RemoveMember(entity);
            }
        }
    }
}
