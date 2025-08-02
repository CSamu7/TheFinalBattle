using Utils;

namespace TheFinalBattle
{
    public class Party
    {
        private readonly int _maxMembers = 3;
        public List<Entity> Members { get; private set; }
        public Inventory Inventory { get; private set; } = new Inventory();

        public IPartyControl PartyControl;
        public int Length { get; private set; } = 0;
        public Party(IPartyControl control)
        {
            Members = new List<Entity>();
            PartyControl = control;
        }
        public Party(IPartyControl control, params Entity[] members)
        {
            PartyControl = control;
            Length += members.Length;
            Members = members.ToList();
        }
        public void RemoveMember(Entity entity)
        {
            Members.Remove(entity);
            Length--;
        }
        public bool AddMember(Entity entity)
        {
            if (Members.Count > _maxMembers)
            {
                return false;
            }

            Members.Add(entity);
            Length++;
            return true;
        }
        public bool AddMembers(List<Entity> members)
        {
            if (Members.Count > _maxMembers)
            {
                return false;
            }

            Members.AddRange(members);
            Length += members.Count;
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
                    enemyInventory.AddItem(entity.Gear.ID);
                }

                RemoveMember(entity);
            }
        }
    }
    public enum PartyControl { AI, Player};
}
