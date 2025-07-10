namespace TheFinalBattle
{
    public class ActionValidator<T> 
    {
        public List<string> Errors { get; set; } = new();
        private List<MenuItemAction<T>> _options;
        public ActionValidator(List<MenuItemAction<T>> options) { 
            _options = options;
        }
        public bool Validate(int indexOption)
        {
            Errors.Clear();

            if (!_options[indexOption].IsAvailable)
            {
                Errors.Add("This action is unavailable");
                return false;
            }

            return true;
        }
    }
    public class InputValidator
    {
        public List<string> Errors { get; set; } = new();
        private int _numOptions { get; init; }
        private bool _isSubmenu { get; init; }
        public int IndexOption;
        public InputValidator(int numOptions, bool isSubmenu)
        {
            _numOptions = numOptions;
            _isSubmenu = isSubmenu;
        }
        public bool Validate(string input)
        {
            Errors.Clear();

            if (!int.TryParse(input, out IndexOption))
            {
                Errors.Add($"You have to enter a valid number");
                return false;
            }

            IndexOption -= 1;

            if (!_isSubmenu && IndexOption == _numOptions)
            {
                Errors.Add($"{IndexOption} is not a valid option.");
                return false;
            }

            if (IndexOption < 0 || IndexOption > _numOptions)
            {
                Errors.Add($"{IndexOption} is not a valid option.");
                return false;
            }

            return true;
        }
    }
}
