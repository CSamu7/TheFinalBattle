using System.Text.Json;
using Utils;

namespace TheFinalBattle.UI
{
    public class LevelsFileMenu
    {
        public void DisplayErrorPath(JsonException error)
        {
            ConsoleUtils.Error(error.Message);
        }
    }
}
