using TheFinalBattle.GameObjects.Entities;
using TheFinalBattle.Interface;
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
        /// <summary>
        /// Returns the winner party
        /// </summary>
        /// <returns></returns>
        public Party Start()
        {
            while (Heroes.Members.Count > 0 && Enemies.Members.Count > 0)
            {
                StartTurn(Heroes);

                if (isBattleFinished()) break;
                    
                StartTurn(Enemies);
            }

            return GetWinnerParty();
        }
        private bool isBattleFinished() =>
            Heroes.Members.Count == 0 || Enemies.Members.Count == 0;
        public Party GetWinnerParty() =>
            Enemies.Members.Count == 0 ? Heroes : Enemies;
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

        //Me sigue sin convencer este metodo
        //Deberiamos crear una clase llamada Turn? La verdad no lo se.
        private void StartTurn(Party actualParty)
        {
            Party enemy = GetEnemyPartyFor(actualParty.Members[0]);

            foreach (Entity entity in actualParty.Members)
            {
                if (enemy.Members.Count <= 0) return;

                _battleStatus.Display(entity, this);
                IEntityCommand command = actualParty.PartyControl.SelectAction(entity, this);
                command.Execute(entity);
                
                enemy.CleanParty(actualParty.Inventory);
                actualParty.CleanParty(enemy.Inventory);
            }
        }
    }
}
