using TheFinalBattle.PlayableClasses;
using TheFinalBattle.PartyControl;
using Utils;

namespace TheFinalBattle
{
    public class Party
    {
        private readonly int _maxMembers = 3;
        public List<Entity> Members { get; init; } = new List<Entity>();
        public Inventory Inventory { get; init; } = new Inventory();
        public IPartyControl PartyControl { get; set; } = new PartyAI();
        public Party(IPartyControl partyControl)
        {
            PartyControl = partyControl;
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
        public void AddMembers(List<Entity> members)
        {
            foreach (Entity member in members)
            {
                if (!AddMember(member)){
                    break;
                }
            }
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
