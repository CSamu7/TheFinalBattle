namespace Utils
{
    public class ConsoleUtils
    {
        public static void Write(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void WriteLine(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Get input from the user and return a lowercase string.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string GetInput(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine() ?? String.Empty;
            return input.Clean();
        }
        public static void Error(string message)
        {
            ConsoleUtils.WriteLine(message, ConsoleColor.Red);
        }

        public static void Warn(string message)
        {
            ConsoleUtils.WriteLine(message, ConsoleColor.Yellow);
        }
    }
}
