using TheFinalBattle.Interface;
using TheFinalBattle.PlayableClasses;
using TheFinalBattle.PlayerCommands;

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
        public void Start()
        {
            while (Heroes.Members.Count > 0 && Enemies.Members.Count > 0)
            {
                StartTurn(Heroes);

                if (Heroes.Members.Count <= 0 || Enemies.Members.Count <= 0) break;
                    
                StartTurn(Enemies);
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
        private void StartTurn(Party actualParty)
        {
            Party enemy = GetEnemyPartyFor(actualParty.Members[0]);

            foreach (Entity entity in actualParty.Members)
            {
                if (enemy.Members.Count <= 0) return;

                _battleStatus.Display(entity, this);
                IEntityCommand command = actualParty.PartyControl.SelectAction(entity, this);
                command.Execute(entity);
                
                Console.WriteLine("-------------------------------------");
                
                enemy.CleanParty(actualParty.Inventory);
                actualParty.CleanParty(enemy.Inventory);
            }
        }
    }
}
