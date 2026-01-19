using TheFinalBattle.Levels.Parser;
using Utils;

namespace TheFinalBattle.UI
{
    public record MappingError(string Message, ErrorType ErrorType);
    public record LevelErrors(List<MappingError> Errors);
    public class FileValidationUI
    {
        private readonly List<List<MappingError>> _errors;
        private readonly string _title = "Validación de Niveles";
        public FileValidationUI(List<List<MappingError>> errors)
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

                if (_errors[i].Count == 0)
                {
                    ConsoleUtils.WriteLine("Valid level", ConsoleColor.Green);
                } else
                {
                    foreach (MappingError error in _errors[i])
                    {
                        DisplayError(error);
                    }
                }
            }
            //TODO: Deberiamos darle la opción al usuario de volver a escoger que niveles quiere cargar
            //o si quiere proseguir.
            Console.ReadLine();
            
            Console.Clear();

        }
        private void DisplayError(MappingError error)
        {
            if (error.ErrorType.Equals(ErrorType.Error))
            {
                ConsoleUtils.Error($" (ERROR) {error.Message}");
            } else
            {
                ConsoleUtils.Warn($" (WARNING) {error.Message}");
            }
        }
    }
}
