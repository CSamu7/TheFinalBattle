using TheFinalBattle.GameObjects.Entities;
using TheFinalBattle.PlayerCommands;
using TheFinalBattle.UI;

namespace TheFinalBattle.PartyControl
{
    /// <summary>
    /// Choose a command by console input.
    /// </summary>
    public class PartyHuman : IPartyControl
    {
        public IEntityCommand SelectAction(Entity entity, Battle battle)
        {
            Party enemyParty = battle.GetEnemyPartyFor(entity);
            MainMenu mainMenu = new(entity, battle);

            while (true)
            {
                //FIX: Codigo poco entendible.
                Func<IEntityCommand?>? commandBuilder = mainMenu.GetOption();

                IEntityCommand? command = commandBuilder();
                if (command is null) continue;

                return command;
            }
        }
    }
}
