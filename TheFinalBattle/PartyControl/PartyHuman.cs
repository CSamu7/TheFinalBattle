using TheFinalBattle.Interface;
using TheFinalBattle.PlayableClasses;
using TheFinalBattle.PlayerCommands;

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
            MainMenu mainMenu = new MainMenu(entity, battle);

            while (true)
            {
                Func<IEntityCommand?>? commandBuilder = mainMenu.GetOption();

                IEntityCommand? command = commandBuilder();
                if (command is null) continue;

                return command;
            }
        }
    }
}
