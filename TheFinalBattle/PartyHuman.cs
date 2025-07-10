namespace TheFinalBattle
{
    /// <summary>
    /// Choose a command by input.
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
