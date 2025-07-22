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
                    Party enemyParty = GetEnemyPartyFor(entity);
                    Console.WriteLine($"The enemy {entity.Name} has dropped the gear: {entity.Gear.Name}");
                    Thread.Sleep(1000);
                    party.Inventory.TransferItem(enemyParty.Inventory, entity.Gear);
                }

                party.RemoveMember(entity);
            }
        }
    }
}
