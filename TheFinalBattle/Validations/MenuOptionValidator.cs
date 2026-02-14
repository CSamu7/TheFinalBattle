namespace TheFinalBattle.Validations
{
    public class MenuOptionValidator
    {
        public List<string> Errors { get; set; } = new();
        private int _numOptions { get; init; }
        private bool _isSubmenu { get; init; }
        public int IndexOption;
        public MenuOptionValidator(int numOptions, bool isSubmenu)
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
                Errors.Add($"{IndexOption + 1} is not a valid option.");
                return false;
            }

            if (IndexOption < 0 || IndexOption > _numOptions)
            {
                Errors.Add($"{IndexOption + 1} is not a valid option.");
                return false;
            }

            return true;
        }
    }
}
