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
        public static string Input(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine() ?? "";
            return input.Clean();
        }
        public static void Error(string message)
        {
            ConsoleUtils.WriteLine(message, ConsoleColor.Red);
        }
    }
}
