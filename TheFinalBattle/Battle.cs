using Utils;

namespace TheFinalBattle
{
    public class Battle
    {
        public Party Heroes {  get; private set; } 
        public Party Enemies { get; private set; }
        private BattleStatus _battleStatus = new();
        public Battle(Party heroes, Party enemies) {
            Enemies = enemies;
            Heroes = heroes;
        }
        public void StartBattle()
        {
            while (Heroes.Length > 0 && Enemies.Length > 0)
            {
                StartPartyTurn(Heroes);
                StartPartyTurn(Enemies);
            }
        }
        public Party GetPartyFor(Entity entity)
        {
            return Heroes.Members.Contains(entity)
                    ? Heroes
                    : Enemies;
        }
        public Party GetEnemyPartyFor(Entity entity)
        {
            return Heroes.Members.Contains(entity)
                    ? Enemies
                    : Heroes;
        }
        private void StartPartyTurn(Party party)
        {
            RemoveDeadMembers(party);

            foreach (Entity entity in party.Members)
            {
                _battleStatus.Display(entity, this);
                IEntityCommand command = party.PartyControl.SelectAction(entity, this);
                command.Execute(entity);
                Console.WriteLine("-------------------------------------");
            }
        }
        private void RemoveDeadMembers(Party party)
        {
            List<Entity> deadMembers = party.Members.Where(member => member.HP <= 0).ToList();

            foreach (Entity entity in deadMembers)
            {
                if(entity.Gear is not null)
                {
                    Console.Write($"The enemy {entity.Name} has dropped the gear: ");
                    ConsoleUtils.WriteLine($"{entity.Gear.Name}", ConsoleColor.Green);
                    Thread.Sleep(1000);
                    party.Inventory.TransferItem(Enemies.Inventory, entity.Gear);
                }

                party.RemoveMember(entity);
            }
        }
    }
}
