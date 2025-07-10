namespace TheFinalBattle
{
    public class Battle
    {
        public Party Heroes {  get; private set; } 
        public Party Enemies { get; private set; }
        private BattleStatus _battleStatus = new BattleStatus();
        public Battle(Party heroes, Party enemies) {
            Enemies = enemies;
            Heroes = heroes;
        }
        public void StartBattle()
        {
            while (Heroes.Length > 0 && Enemies.Length > 0)
            {
                StartTurn(Heroes);
                StartTurn(Enemies);
            }

            Console.WriteLine("The battle has finished!");
            Thread.Sleep(500);
        }
        public Party GetPartyFor(Entity entity)
        {
            if (Heroes.Members.Contains(entity))
            {
                return Heroes;
            }

            return Enemies;
        }
        public Party GetEnemyPartyFor(Entity entity)
        {
            if (Heroes.Members.Contains(entity))
            {
                return Enemies;
            }

            return Heroes;
        }
        private void StartTurn(Party party)
        {
            party.RemoveDeadMembers();
            
            foreach (Entity entity in party.Members)
            {
                _battleStatus.Display(entity, this);
                Console.WriteLine($"It is {entity.Name} turn...");

                IEntityCommand command = party.PartyControl.SelectAction(entity, this);
                command.Execute(entity);
                
                Console.WriteLine("-------------------------------------");
            }

        }
    }
}
