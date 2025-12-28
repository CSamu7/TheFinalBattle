using Utils;

namespace TheFinalBattle.UI
{
    public enum ErrorType { Warn, Error}
    public record LevelError(string Message, ErrorType ErrorType);
    public record LevelErrors(List<LevelError> Errors);
    public class FileValidationUI
    {
        private readonly List<LevelErrors> _errors;
        private string _title = "Validación de Niveles";
        public FileValidationUI(List<LevelErrors> errors)
        {
            _errors = errors;
        }
        public void Display()
        {
            Console.Clear();
            Console.WriteLine(_title);

            for (int i = 0; i < _errors.Count; i++)
            {
                Console.WriteLine($"Level {i + 1}:");

                var errorsInLevel = _errors[i].Errors;
                DisplayLevelErrors(errorsInLevel);
            }

            //Deberiamos darle la opción al usuario de volver a escoger que niveles quiere cargar
            //o si quiere proseguir.
            Thread.Sleep(2000);
            
            Console.Clear();

        }
        private void DisplayLevelErrors(List<LevelError> errorsInLevel)
        {
            if (errorsInLevel.Count == 0)
            {
                ConsoleUtils.WriteLine("No errors found!", ConsoleColor.Green);
                return;
            }

            foreach (var error in errorsInLevel)
            {
                DisplayError(error);
            }
        }
        private void DisplayError(LevelError error)
        {
            if (error.Equals(ErrorType.Error))
            {
                ConsoleUtils.Error($" (ERROR) {error.Message}");
            } else
            {
                ConsoleUtils.Warn($" (WARNING) {error.Message}");
            }
        }
    }
}
