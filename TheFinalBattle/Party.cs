using TheFinalBattle.PlayableClasses;
using TheFinalBattle.PartyControl;
using Utils;
using TheFinalBattle.Items;

namespace TheFinalBattle
{
    public class Party
    {
        private readonly int _maxMembers = 3;
        public List<Entity> Members { get; init; } = new List<Entity>();
        public Inventory Inventory { get; init; } = new Inventory();
        public IPartyControl PartyControl { get; set; } = new PartyAI();
        public Party(params Entity[] members)
        {
            AddMembers(members); 
        }
        public Party(IPartyControl control, params Entity[] members)
        {
            PartyControl = control;
            AddMembers(members);
        }
        public bool AddMembers(params Entity[] members)
        {
            if (Members.Count() >= _maxMembers)
                return false;

            Members.AddRange(members);
            return true;
        }
        public void RemoveMember(Entity entity) =>
            Members.Remove(entity);
        public void CleanParty(Inventory enemyInventory)
        {
            List<Entity> deadMembers = Members.Where(member => member.HP <= 0).ToList();

            foreach (Entity entity in deadMembers)
            {
                Gear? gear = entity.Kill();
                if(gear is not null) enemyInventory.AddItem(gear);
                RemoveMember(entity);
            }
        }
    }
}

public enum PartyControl { AI, Player };
