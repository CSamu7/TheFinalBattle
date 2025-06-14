using Utils;

namespace TheFinalBattle
{
    public class PartyHuman : IPartyControl
    {
        private readonly MenuOptions _menuOptions = new MenuOptions();
        public void Act(Entity entity, Battle battle)
        {
            IEntityCommand command = SelectAction(entity, battle);
            command.Execute(entity);
        }
        public IEntityCommand SelectAction(Entity entity, Battle battle)
        {
            Party enemyParty = battle.GetEnemyPartyFor(entity);
            IEntityCommand? command = null;
            int inputUser;

            do
            {
                Console.WriteLine("YOUR ACTIONS: ");
                List<MenuOption> options = _menuOptions.GenerateMainOptions(entity, battle);

                DisplayOptions(options);
                Console.Write("What do you want to do? ");
                
                if(!int.TryParse(Console.ReadLine(), out inputUser))
                {
                    ConsoleUtils.WriteLine("Enter a number...", ConsoleColor.Red);
                    continue;
                }

                EntityActions? mainAction = ParseMainAction(inputUser);

                command = mainAction switch
                {
                    EntityActions.Attack => new AttackSubmenu(enemyParty).GetAttack(entity),
                    EntityActions.DoNothing => new DoNothing(),
                    EntityActions.UseItem => new ItemSubmenu(entity, battle).GetItem(),
                    _ => null
                };
            }
            while (command is null);

            return command;
        }

        //Refactor?
        private void DisplayOptions(List<MenuOption> options)
        {
            for (int i = 0; i < options.Count; i++)
            {
                MenuOption option = options[i];

                if (option.isAvailable)
                {
                    Console.WriteLine($"({i+1}) {option.Description}");
                } else
                {
                    ConsoleUtils.WriteLine($"({i+1}) {option.Description}", ConsoleColor.Gray);
                }
            }
        }
        private EntityActions? ParseMainAction(int userInput)
        {
            return userInput switch
            {
                1 => EntityActions.DoNothing,
                2 => EntityActions.Attack,
                3 => EntityActions.UseItem,
                _ => null
            };
        }
    }
}
