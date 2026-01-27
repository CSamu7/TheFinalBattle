using System.Data;
using TheFinalBattle.Levels.Mappers;
using Utils;

namespace TheFinalBattle.UI
{
    public record MappingAlert(string Message, AlertType AlertType);
    public record LevelErrors(List<MappingAlert> Errors);
    public class FileValidationUI
    {
        private readonly LevelsResult _results;
        private readonly List<List<MappingAlert>> _alerts;
        private readonly string _title = "Validación de Niveles";
        public FileValidationUI(LevelsResult results)
        {
            _results = results;
            _alerts = results.Alerts;
        }
        public void Display()
        {
            Console.Clear();
            Console.WriteLine(_title);

            for (int i = 0; i < _alerts.Count; i++)
            {
                Console.WriteLine($"Level {i + 1}:");

                foreach (MappingAlert alert in _alerts[i])
                {
                    DisplayAlert(alert);
                }
            }

            Console.WriteLine($"{_results.Levels.Count}/{_results.LevelsChecked} valid levels.");
            Console.WriteLine("Press any key");
            Console.ReadLine();
        }
        private void DisplayAlert(MappingAlert alert)
        {
            if (alert.AlertType.Equals(AlertType.Error))
            {
                ConsoleUtils.Error($" (ERROR) {alert.Message}");
            } else if(alert.AlertType.Equals(AlertType.Warn))
            {
                ConsoleUtils.Warn($" (WARNING) {alert.Message}");
            } else
            {
                Console.WriteLine($" {alert.Message}");
            }
        }
    }
}
