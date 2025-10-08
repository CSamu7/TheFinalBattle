using TheFinalBattle.PlayableClasses;

namespace TheFinalBattle.PlayerCommands
{
    public class RemoveGear : IEntityCommand
    {
        private Battle _battle;
        public RemoveGear(Battle battle)
        {
            _battle = battle;
        }
        public void Execute(Entity entity)
        {
            Party party = _battle.GetPartyFor(entity);

            party.Inventory.AddItem(entity.Gear);
            Console.WriteLine($"{entity.Name} has removed its {entity.Gear.Name}");
            entity.Gear = null;
        }
    }
}
