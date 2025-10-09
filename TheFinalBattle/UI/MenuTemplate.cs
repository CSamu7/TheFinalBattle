using Utils;
namespace TheFinalBattle.Interface
{
    public abstract class MenuTemplate<T> where T : class
    {
        protected abstract List<MenuItemAction<T>> Options { get; set; }
        protected string MenuTitle { get; set; } = string.Empty;
        protected string InputText { get; set; } = string.Empty;
        protected bool IsSubmenu { get; set; } = true;
        private int _indexOption;
        public T? GetOption()
        {
            while (true)
            {
                DisplayMenu();

                Console.Write(InputText);
                MenuState state = ValidateInput();

                if (state is MenuState.InvalidInput) continue;
                if (state is MenuState.BackPrevMenu) return null;

                return Options[_indexOption].Action;
            }
        }
        private MenuState ValidateInput()
        {
            ActionValidator<T> optionValidator = new ActionValidator<T>(Options);
            InputValidator basicValidator = new InputValidator(Options.Count, IsSubmenu);

            if (!basicValidator.Validate(Console.ReadLine() ?? ""))
            {
                ConsoleUtils.Error(basicValidator.Errors[0]);
                return MenuState.InvalidInput;
            }

            _indexOption = basicValidator.IndexOption;
            //If the user wants to comeback to the prev menu.
            if (IsSubmenu && _indexOption == Options.Count) return MenuState.BackPrevMenu;
            
            if (!optionValidator.Validate(_indexOption))
            {
                ConsoleUtils.Error(optionValidator.Errors[0]);
                return MenuState.InvalidInput;
            }

            return MenuState.ValidItem;
        }
        public virtual void DisplayMenu()
        {
            Console.WriteLine($"{MenuTitle}");

            DisplayItems();

            if (IsSubmenu)
            {
                Console.WriteLine($"({Options.Count + 1}) Back");
            }
        }
        public virtual void DisplayItems()
        {
            Options.DisplayList(menuItem =>
            {
                if (!menuItem.IsAvailable)
                {
                    ConsoleUtils.WriteLine(menuItem.Text, ConsoleColor.Gray);
                } else
                {
                    Console.WriteLine(menuItem.Text);
                }
            });
        }
    }
}
