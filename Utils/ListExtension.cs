namespace Utils
{
    public static class ListExtensions
    {
        public static void DisplayList<T>(this List<T> list, Action<T> text)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"({i + 1}) ");
                text.Invoke(list[i]);
            }
        }
    }
}
