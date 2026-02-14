namespace TheFinalBattle.Validations
{
    public class ActionValidator<T>
    {
        public List<string> Errors { get; set; } = new();
        private List<MenuItemAction<T>> _options;
        public ActionValidator(List<MenuItemAction<T>> options)
        {
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
}
