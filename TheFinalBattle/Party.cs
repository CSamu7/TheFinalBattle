namespace TheFinalBattle
{
    public class Party
    {
        private readonly int _maxMembers = 3;
        public List<Entity> Members { get; private set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public IPartyControl Control;
        public int Length { get; private set; } = 0;
        public Party(IPartyControl control)
        {
            Members = new List<Entity>();
            Control = control;
        }
        public Party(IPartyControl control, params Entity[] members)
        {
            Control = control;
            Length += members.Length;
            Members = members.ToList();
        }
        public void AddItem(Item item, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Items.Add(item);
            }
        }
        public Entity GetMemberAt(int index) => Members[index];
        public void RemoveMember(Entity entity) => Members.Remove(entity);
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
        public void RemoveDeadMembers()
        {
            List<Entity> deadMembers = Members.Where(member => member.HP <= 0).ToList();

            foreach (Entity entity in deadMembers)
            {
                Members.Remove(entity);
                Console.WriteLine($"{entity.Name} has been defeated!");
                Length--;
            }

        }
    }
    public enum PartyControl { AI, Player};
}
