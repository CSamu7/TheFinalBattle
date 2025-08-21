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
        public void StartBattle()
        {
            while (Heroes.Length > 0 && Enemies.Length > 0)
            {
                StartTurn(Heroes);

                if (Heroes.Length <= 0 || Enemies.Length <= 0) break;
                    
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
                if (enemy.Length <= 0) return;

                _battleStatus.Display(entity, this);
                IEntityCommand command = actualParty.PartyControl.SelectAction(entity, this);
                command.Execute(entity);
                
                Console.WriteLine("-------------------------------------");
                
                enemy.RemoveDeadMembers(actualParty.Inventory);
                actualParty.RemoveDeadMembers(enemy.Inventory);
            }
        }
    }
}
